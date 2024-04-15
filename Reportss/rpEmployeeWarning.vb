Imports System
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document 
Imports System.Globalization

Public Class rpEmployeeWarning 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        If TextBox11.Text <> "" Then
            TextBox11.Visible = True
            Label18.Visible = True
            TextBox20.Visible = True
            Label29.Visible = True
        Else
            TextBox11.Visible = False
            Label18.Visible = False

        End If

        If TextBox12.Text <> "" Then
            TextBox12.Visible = True
            Label20.Visible = True
            TextBox14.Visible = True
            Label30.Visible = True
        Else
            TextBox12.Visible = False
            Label20.Visible = False
            TextBox14.Visible = False
            Label30.Visible = False
        End If

        If TextBox13.Text <> "" Then
            TextBox13.Visible = True
            Label22.Visible = True
            TextBox15.Visible = True
            Label31.Visible = True
        Else
            TextBox13.Visible = False
            Label22.Visible = False
        End If
        If TextBox15.Text = "0" Then
            TextBox15.Visible = False
            Label31.Visible = False
        End If
        If TextBox14.Text = "0" Then
            TextBox14.Visible = False
            Label30.Visible = False
        Else
            'TextBox12.Visible = True
            'Label20.Visible = True
            TextBox14.Visible = True
            Label30.Visible = True
        End If
        If TextBox20.Text = "0" Then
            TextBox20.Visible = False
            Label29.Visible = False
        End If

    End Sub
End Class
