Imports System.Diagnostics.Eventing.Reader
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class Form1

    ' Variables for dragging the form
    Private drag As Boolean
    Private mouseX As Integer
    Private mouseY As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add click event handlers
        AddHandler CloseWindow1.Click, AddressOf CloseWindow1_Click
        AddHandler MinimizedWindow1.Click, AddressOf MinimizedWindow1_Click
        AddHandler MaximizeWindow1.MouseEnter, AddressOf MaximizeWindow1_MouseEnter
        AddHandler MaximizeWindow1.MouseLeave, AddressOf MaximizeWindow1_MouseLeave

        ' Add hover effect event handlers
        AddHandler CloseWindow1.MouseEnter, AddressOf CloseWindow1_MouseEnter
        AddHandler CloseWindow1.MouseLeave, AddressOf CloseWindow1_MouseLeave
        AddHandler MinimizedWindow1.MouseEnter, AddressOf MinimizedWindow1_MouseEnter
        AddHandler MinimizedWindow1.MouseLeave, AddressOf MinimizedWindow1_MouseLeave

        ' Add dragging events to the Panel
        AddHandler Guna2CustomGradientPanel1.MouseDown, AddressOf Panel_MouseDown
        AddHandler Guna2CustomGradientPanel1.MouseMove, AddressOf Panel_MouseMove
        AddHandler Guna2CustomGradientPanel1.MouseUp, AddressOf Panel_MouseUp


    End Sub

    ' Event handler for close button click
    Private Sub CloseWindow1_Click(sender As Object, e As EventArgs)
        Me.Close() ' Close the form
    End Sub

    ' Event handlers for CloseWindow1 hover effects
    Private Sub CloseWindow1_MouseEnter(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Hand  ' Change cursor to hand on hover
    End Sub

    Private Sub CloseWindow1_MouseLeave(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Default  ' Revert cursor to default
    End Sub

    ' Event handler for minimize button click
    Private Sub MinimizedWindow1_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    ' Event handlers for MinimizedWindow1 hover effects
    Private Sub MinimizedWindow1_MouseEnter(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Hand  ' Change cursor to hand on hover
    End Sub

    Private Sub MinimizedWindow1_MouseLeave(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Default  ' Revert cursor to default
    End Sub

    ' Mouse Down event to start dragging
    Private Sub Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        drag = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    ' Mouse Move event to drag the form
    Private Sub Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    ' Mouse Up event to stop dragging
    Private Sub Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        drag = False
    End Sub
    Private Sub MaximizeWindow1_MouseEnter(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Hand  ' Change cursor to hand on hover
    End Sub

    Private Sub MaximizeWindow1_MouseLeave(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Cursor = Cursors.Default  ' Revert cursor to default
    End Sub
    Private Sub MaximizeWindow1_Click(sender As Object, e As EventArgs) Handles MaximizeWindow1.Click
        If Me.WindowState = FormWindowState.Normal Then
            ' Maximize the form
            Me.WindowState = FormWindowState.Maximized
            ' Manually set the form size to fill the screen
            Me.Bounds = Screen.PrimaryScreen.Bounds

        Else
            ' Restore the form to its normal size
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class
