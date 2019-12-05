Public Class JogoVelha
    Private Sub JogoVelha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Atribui evento btn_Click todos os botões
        For Each c As Control In pnl2.Controls
            If c.GetType() = GetType(Button) Then
                AddHandler c.Click, AddressOf btn_Click
            End If
        Next
    End Sub

    Dim xo As Integer = 0
    Private Sub btn_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        'Verifica se o botão está em branco
        If btn.Text.Equals("") Then
            'Se a variável for par
            If xo Mod 2 = 0 Then
                btn.Text = "X"
                btn.ForeColor = Color.Red
                lbl2.Text = "2(O)"
                vencedor()
                'Se a variável for ímpar
            Else
                btn.Text = "O"
                btn.ForeColor = Color.Blue
                lbl2.Text = "1(X)"
                vencedor()
            End If
            xo += 1
        End If
    End Sub

    Dim venc As Boolean = False
    Private Sub vencedor()
        'Fileiras Horizontais
        If Not btn1.Text.Equals("") AndAlso btn1.Text.Equals(btn2.Text) AndAlso btn2.Text.Equals(btn3.Text) Then
            venc = True
            msgVencedor(btn1, btn2, btn3)
        ElseIf Not btn4.Text.Equals("") AndAlso btn4.Text.Equals(btn5.Text) AndAlso btn5.Text.Equals(btn6.Text) Then
            venc = True
            msgVencedor(btn4, btn5, btn6)
        ElseIf Not btn7.Text.Equals("") AndAlso btn7.Text.Equals(btn8.Text) AndAlso btn8.Text.Equals(btn9.Text) Then
            venc = True
            msgVencedor(btn7, btn8, btn9)

            'Fileiras Verticais
        ElseIf Not btn1.Text.Equals("") AndAlso btn1.Text.Equals(btn4.Text) AndAlso btn4.Text.Equals(btn7.Text) Then
            venc = True
            msgVencedor(btn1, btn4, btn7)
        ElseIf Not btn2.Text.Equals("") AndAlso btn2.Text.Equals(btn5.Text) AndAlso btn5.Text.Equals(btn8.Text) Then
            venc = True
            msgVencedor(btn2, btn5, btn8)
        ElseIf Not btn3.Text.Equals("") AndAlso btn3.Text.Equals(btn6.Text) AndAlso btn6.Text.Equals(btn9.Text) Then
            venc = True
            msgVencedor(btn3, btn6, btn9)

            'Fileiras Diagonais
        ElseIf Not btn1.Text.Equals("") AndAlso btn1.Text.Equals(btn5.Text) AndAlso btn5.Text.Equals(btn9.Text) Then
            venc = True
            msgVencedor(btn1, btn5, btn9)
        ElseIf Not btn3.Text.Equals("") AndAlso btn3.Text.Equals(btn5.Text) AndAlso btn5.Text.Equals(btn7.Text) Then
            venc = True
            msgVencedor(btn3, btn5, btn7)
        End If
        'Todos botões preenchidos e não houver vencedor
        If btnsPreenchidos() = 9 AndAlso venc = False Then
            MsgBox("Sem Vencedor")
        End If
    End Sub

    Function btnsPreenchidos() As Integer
        'Conta a quantidade de botões preenchidos
        Dim btns As Integer = 0
        For Each c As Control In pnl2.Controls
            If c.GetType() = GetType(Button) Then
                btns += c.Text.Length
            End If
        Next
        Return btns
    End Function

    Private Sub msgVencedor(ByVal b1 As Button, ByVal b2 As Button, ByVal b3 As Button)
        'Altera a cor dos blocos em sequência
        b1.BackColor = Color.GreenYellow
        b2.BackColor = Color.GreenYellow
        b3.BackColor = Color.GreenYellow
        'Mostra na tela o Vencedor
        If b1.Text.Equals("X") AndAlso b1.Text.Equals(b2.Text) AndAlso b2.Text.Equals(b3.Text) Then
            MsgBox("Jogador 1 venceu")
        ElseIf b1.Text.Equals("O") AndAlso b1.Text.Equals(b2.Text) AndAlso b2.Text.Equals(b3.Text) Then
            MsgBox("Jogador 2 venceu")
        End If
        'Desativa todos os botões após confirmar o vencedor
        For Each c As Control In pnl2.Controls
            If c.GetType() = GetType(Button) Then
                c.Enabled = False
            End If
        Next

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        'Reseta as variáveis e todos os botões
        xo = 0
        venc = False
        lbl2.Text = "1(X)"
        For Each c As Control In pnl2.Controls
            If c.GetType() = GetType(Button) Then
                c.Enabled = True
                c.BackColor = Color.White
                c.Text = ""
            End If
        Next
    End Sub

End Class
