Imports Codeer.Friendly
Imports Codeer.Friendly.Windows.Grasp
Imports NUnit.Framework
Imports Ong.Friendly.FormsStandardControls
Imports TechTalk.SpecFlow

Namespace Features.Steps

    <Binding()> _
    Public Class StepDefinitions

        Private Shared ReadOnly Form1DriverName As String = GetType(Form1Driver).FullName
        Private Property driver() As Form1Driver
            Get
                If Not ScenarioContext.Current.ContainsKey(Form1DriverName) Then
                    Return Nothing
                End If
                Return ScenarioContext.Current.Get(Of Form1Driver)(Form1DriverName)
            End Get
            Set(ByVal value As Form1Driver)
                ScenarioContext.Current.Set(value, Form1DriverName)
            End Set
        End Property

        <AfterScenario()> Public Sub AfterScenario()
            If driver Is Nothing Then
                Return
            End If
            driver.Dispose()
        End Sub

        <Given("起動する")> _
        Public Sub Given起動する()
            driver = Form1Driver.Start
        End Sub

        <TechTalk.SpecFlow.When("TextBox ""(.+)"" に ""(.+)"" を入力する")> _
        Public Sub WhenTextBoxにvalueを入力する(ByVal name As String, ByVal value As String)
            Dim textbox As New FormsTextBox(driver.App, driver.MainForm(name)())
            textbox.EmulateChangeText(value)
        End Sub

        <TechTalk.SpecFlow.When("Button ""(.+)"" を押す")> _
        Public Sub WhenButtonを押す(ByVal buttonLabel As String)
            Dim controls As WindowControl() = driver.MainForm.GetFromWindowText(buttonLabel)
            Assert.That(controls, [Is].Not.Empty, buttonLabel & " があるはず")

            Dim button As New FormsButton(controls(0))
            button.EmulateClick()
        End Sub

        <TechTalk.SpecFlow.Then("TextBox ""(.+)"" は ""(.+)"" になる")> _
        Public Sub ThenTextBoxはvalueになる(ByVal name As String, ByVal expectedValue As String)
            Dim textbox As New FormsTextBox(driver.App, driver.MainForm(name)())
            Assert.That(textbox.Text, [Is].EqualTo(expectedValue))
        End Sub

    End Class
End Namespace