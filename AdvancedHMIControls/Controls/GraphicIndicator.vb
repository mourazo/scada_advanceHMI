Imports System.Drawing
'****************************************************************************
'* 12-DEC-08 Added line in OnPaint to exit is LegendText is nothing
'* 05-OCT-09 Exit OnPaint if GrayPen is Nothing
'****************************************************************************
Public Class GraphicIndicator
    Inherits MfgControl.AdvancedHMI.Controls.GraphicIndicator

#Region "PLC Related Properties"
    '*****************************************************
    '* Property - Component to communicate to PLC through
    '*****************************************************
    Private m_ComComponent As MfgControl.AdvancedHMI.Drivers.IComComponent
    Public Property ComComponent() As MfgControl.AdvancedHMI.Drivers.IComComponent
        Get
            Return m_ComComponent
        End Get
        Set(ByVal value As MfgControl.AdvancedHMI.Drivers.IComComponent)
            If m_ComComponent IsNot value Then
                If SubScriptions IsNot Nothing Then
                    SubScriptions.UnsubscribeAll()
                End If

                m_ComComponent = value

                SubscribeToComDriver()
            End If
        End Set
    End Property


    '*****************************************
    '* Property - Address in PLC to Link to
    '*****************************************
    Private m_PLCAddressSelect1 As String = ""
    Public Property PLCAddressValueSelect1() As String
        Get
            Return m_PLCAddressSelect1
        End Get
        Set(ByVal value As String)
            If m_PLCAddressSelect1 <> value Then
                m_PLCAddressSelect1 = value
                '* When address is changed, re-subscribe to new address
                SubscribeToComDriver()
            End If
        End Set
    End Property

    '*****************************************
    '* Property - Address in PLC to Link to
    '*****************************************
    Private m_PLCAddressSelect2 As String = ""
    Public Property PLCAddressValueSelect2() As String
        Get
            Return m_PLCAddressSelect2
        End Get
        Set(ByVal value As String)
            If m_PLCAddressSelect2 <> value Then
                m_PLCAddressSelect2 = value
                '* When address is changed, re-subscribe to new address
                SubscribeToComDriver()
            End If
        End Set
    End Property

    '*****************************************
    '* Property - Address in PLC to Link to
    '*****************************************
    Private m_PLCAddressVisible As String = ""
    Public Property PLCAddressVisible() As String
        Get
            Return m_PLCAddressVisible
        End Get
        Set(ByVal value As String)
            If m_PLCAddressVisible <> value Then
                m_PLCAddressVisible = value
                '* When address is changed, re-subscribe to new address
                SubscribeToComDriver()
            End If
        End Set
    End Property


    '*****************************************
    '* Property - Address in PLC to Link to
    '*****************************************
    Private m_PLCAddressText2 As String = ""
    Public Property PLCAddressText2() As String
        Get
            Return m_PLCAddressText2
        End Get
        Set(ByVal value As String)
            If m_PLCAddressText2 <> value Then
                m_PLCAddressText2 = value
                '* When address is changed, re-subscribe to new address
                SubscribeToComDriver()
            End If
        End Set
    End Property

    '*****************************************
    '* Property - Address in PLC to Link to
    '*****************************************
    Private m_PLCAddressClick As String = ""
    Public Property PLCAddressClick() As String
        Get
            Return m_PLCAddressClick
        End Get
        Set(ByVal value As String)
            m_PLCAddressClick = value
        End Set
    End Property

    Private m_SuppressErrorDisplay As Boolean
    <System.ComponentModel.DefaultValue(False)> _
    Public Property SuppressErrorDisplay As Boolean
        Get
            Return m_SuppressErrorDisplay
        End Get
        Set(value As Boolean)
            m_SuppressErrorDisplay = value
        End Set
    End Property
#End Region

#Region "Constructor/Destructor"
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If SubScriptions IsNot Nothing Then
                    SubScriptions.dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region


#Region "Events"
    '****************************
    '* Event - Mouse Down
    '****************************
    Private Sub MomentaryButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (m_PLCAddressClick IsNot Nothing AndAlso (String.Compare(m_PLCAddressClick, "") <> 0)) AndAlso m_ComComponent IsNot Nothing Then
            Try
                Select Case OutputType
                    Case OutputTypes.MomentarySet : m_ComComponent.Write(m_PLCAddressClick, 1)
                    Case OutputTypes.MomentaryReset : m_ComComponent.Write(m_PLCAddressClick, 0)
                    Case OutputTypes.SetTrue : m_ComComponent.Write(m_PLCAddressClick, 1)
                    Case OutputTypes.SetFalse : m_ComComponent.Write(m_PLCAddressClick, 0)
                    Case OutputTypes.Toggle
                        Dim CurrentValue As Boolean
                        CurrentValue = m_ComComponent.Read(m_PLCAddressClick, 1)(0)
                        If CurrentValue Then
                            m_ComComponent.Write(m_PLCAddressClick, 0)
                        Else
                            m_ComComponent.Write(m_PLCAddressClick, 1)
                        End If
                End Select
            Catch
            End Try
        End If
    End Sub


    '****************************
    '* Event - Mouse Up
    '****************************
    Private Sub MomentaryButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If (m_PLCAddressClick IsNot Nothing AndAlso (String.Compare(m_PLCAddressClick, "") <> 0)) AndAlso m_ComComponent IsNot Nothing Then
            Try
                Select Case OutputType
                    Case OutputTypes.MomentarySet : m_ComComponent.Write(m_PLCAddressClick, 0)
                    Case OutputTypes.MomentaryReset : m_ComComponent.Write(m_PLCAddressClick, 1)
                End Select
                'tmrError.Enabled = False
            Catch
            End Try
        End If
    End Sub

    Private Sub GraphicIndicator_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Me.Invalidate()
    End Sub


    '* This is part of the transparent background code and it stops flicker
    'Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    'MyBase.OnPaintBackground(e)
    'End Sub


    '********************************************************************
    '* When an instance is added to the form, set the comm component
    '* property. If a comm component does not exist, add one to the form
    '********************************************************************
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()

        If Me.DesignMode Then
            'If Me Is Nothing OrElse Me.Parent Is Nothing OrElse Me.Parent.Site Is Nothing Then Exit Sub

            '********************************************************
            '* Search for AdvancedHMIDrivers.IComComponent component in parent form
            '* If one exists, set the client of this component to it
            '********************************************************
            Dim i = 0
            Dim j As Integer = Me.Parent.Site.Container.Components.Count
            While m_ComComponent Is Nothing And i < j
                If Me.Parent.Site.Container.Components(i).GetType.GetInterface("IComComponent") IsNot Nothing Then m_ComComponent = CType(Me.Parent.Site.Container.Components(i), MfgControl.AdvancedHMI.Drivers.IComComponent)
                i += 1
            End While

            '************************************************
            '* If no comm component was found, then add one and
            '* point the ComComponent property to it
            '*********************************************
            If m_ComComponent Is Nothing Then
                m_ComComponent = New AdvancedHMIDrivers.EthernetIPforCLXCom(Me.Site.Container)
            End If
        Else
            SubscribeToComDriver()
        End If
    End Sub


#End Region

#Region "Subscribing and PLC data receiving"
    Private SubScriptions As SubscriptionHandler
    '**************************************************
    '* Subscribe to addresses in the Comm(PLC) Driver
    '**************************************************
    Private Sub SubscribeToComDriver()
        If Not DesignMode And IsHandleCreated Then
            '* Create a subscription handler object
            If SubScriptions Is Nothing Then
                SubScriptions = New SubscriptionHandler
                SubScriptions.Parent = Me
                AddHandler SubScriptions.DisplayError, AddressOf DisplaySubscribeError
            End If
            SubScriptions.ComComponent = m_ComComponent

            SubScriptions.subscribeAutoProperties()
        End If
    End Sub

    '***************************************
    '* Call backs for returned data
    '***************************************
    Private OriginalText As String
    Private Sub PolledDataReturned(ByVal sender As Object, ByVal e As SubscriptionHandlerEventArgs)
    End Sub

    Private Sub DisplaySubscribeError(ByVal sender As Object, ByVal e As MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs)
        DisplayError(e.ErrorMessage)
    End Sub
#End Region

#Region "Error Display"
    '********************************************************
    '* Show an error via the text property for a short time
    '********************************************************
    Private WithEvents ErrorDisplayTime As System.Windows.Forms.Timer
    Private Sub DisplayError(ByVal ErrorMessage As String)
        If Not m_SuppressErrorDisplay Then
            If ErrorDisplayTime Is Nothing Then
                ErrorDisplayTime = New System.Windows.Forms.Timer
                AddHandler ErrorDisplayTime.Tick, AddressOf ErrorDisplay_Tick
                ErrorDisplayTime.Interval = 5000
            End If

            '* Save the text to return to
            If Not ErrorDisplayTime.Enabled Then
                OriginalText = Me.Text
            End If

            ErrorDisplayTime.Enabled = True

            Me.Text = ErrorMessage
        End If
    End Sub


    '**************************************************************************************
    '* Return the text back to its original after displaying the error for a few seconds.
    '**************************************************************************************
    Private Sub ErrorDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Text = OriginalText

        If ErrorDisplayTime IsNot Nothing Then
            ErrorDisplayTime.Enabled = False
            ErrorDisplayTime.Dispose()
            ErrorDisplayTime = Nothing
        End If
    End Sub
#End Region

End Class
