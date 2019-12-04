Public Class frmCalc
    Public num1 As Double
    Public num2 As Double
    Public res As Double

    Private Sub txtNum1_KeyPress(sender As Object, x As EventArgs) Handles txtNum1.KeyPress
        apenasNum(x)
    End Sub

    Private Sub txtNum2_KeyPress(sender As Object, x As EventArgs) Handles txtNum2.KeyPress
        apenasNum(x)
    End Sub

    Public Sub apenasNum(ByVal x As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(x.KeyChar) >= 48 And Asc(x.KeyChar) <= 57) Or Asc(x.KeyChar) = 46 Or Asc(x.KeyChar) = 8 Then
            'Asc(x.KeyChar) >= 48 And Asc(x.KeyChar) <= 57 // Permite apenas a entrada de 0 a 9
            'Asc(x.KeyChar) = 46 // Permite a entrada do ponto "."
            'Asc(x.KeyChar) = 8 // Permite apagar usando o backspace
        Else
            x.Handled = True
            'MsgBox("Apenas Numeros")
        End If
    End Sub

    Private Sub btnSoma_Click(sender As Object, e As EventArgs) Handles btnSoma.Click
        If (txtNum1.Text.Equals("")) Then
            MsgBox("Preencha o campos")
        Else
            num1 = Val(txtNum1.Text)
            num2 = Val(txtNum2.Text)
            res = num1 + num2
            lblRes.Text = res
            txtNum1.Text = ""
            txtNum2.Text = ""
        End If
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        If (txtNum1.Text.Equals("")) Then
            MsgBox("Preencha o campos")
        Else
            num1 = Val(txtNum1.Text)
            num2 = Val(txtNum2.Text)
            res = num1 - num2
            lblRes.Text = res
            txtNum1.Text = ""
            txtNum2.Text = ""
        End If
    End Sub
End Class
