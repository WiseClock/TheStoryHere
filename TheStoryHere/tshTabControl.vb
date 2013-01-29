Imports System.Windows.Forms.VisualStyles

Public Class tshTabControl
    Inherits TabControl

    Private CLOSE_SIZE As Integer = 12

    Friend Sub New()
        MyBase.New()
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        TabStop = False
        ImageList = Main.iconList
        Dock = DockStyle.Fill
        TabPages.Add(New tshTabs)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        DrawControl(e.Graphics)
    End Sub

    'http://www.codeproject.com/Articles/13758/Applying-Visual-Styles-to-the-TabControl-in-NET-2
    Friend Sub DrawControl(ByVal g As Graphics)
        If Not Visible Then
            Return
        End If
        Dim render As New VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal)
        Dim TabControlArea As Rectangle = Me.ClientRectangle
        Dim TabArea As Rectangle = Me.DisplayRectangle
        TabArea.Y = TabArea.Y + 1
        TabArea.Width = TabArea.Width + 1
        Dim nDelta As Integer = SystemInformation.Border3DSize.Width
        TabArea.Inflate(nDelta, nDelta)
        render.DrawBackground(g, TabArea)
        Dim i As Integer = 0
        While i < Me.TabCount
            DrawTab(g, Me.TabPages(i), i)
            i += 1
        End While
    End Sub

    'http://www.codeproject.com/Articles/13758/Applying-Visual-Styles-to-the-TabControl-in-NET-2
    Friend Sub DrawTab(ByVal g As Graphics, ByVal tabPage As TabPage, ByVal nIndex As Integer)
        Dim recBounds As Rectangle = Me.GetTabRect(nIndex)

        Dim tabTextArea As RectangleF = CType(Me.GetTabRect(nIndex), RectangleF)
        Dim bSelected As Boolean = (Me.SelectedIndex = nIndex)
        Dim render As New VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal)
        render = New VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Pressed)
        If bSelected Then
            recBounds.Height = recBounds.Height + 10
            render = New VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Pressed)
            render.DrawBackground(g, recBounds)
            render.DrawEdge(g, recBounds, Edges.Diagonal, EdgeStyle.Sunken, EdgeEffects.Flat)
        Else
            recBounds.Y = recBounds.Y + 1
            render = New VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal)
            render.DrawBackground(g, recBounds)
            render.DrawEdge(g, recBounds, Edges.Diagonal, EdgeStyle.Sunken, EdgeEffects.Flat)
        End If
        If (tabPage.ImageIndex >= 0) AndAlso (Not (ImageList Is Nothing)) AndAlso (Not (ImageList.Images(tabPage.ImageIndex) Is Nothing)) Then
            Dim nLeftMargin As Integer = 2
            Dim nRightMargin As Integer = 0
            Dim img As Image = ImageList.Images(tabPage.ImageIndex)
            Dim rimage As Rectangle = New Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height)
            Dim nAdj As Single = CType((nLeftMargin + img.Width + nRightMargin), Single)
            'rimage.Y += (recBounds.Height - img.Height) / 2
            rimage.Y = 5
            'tabTextArea.X += nAdj
            'tabTextArea.Width -= nAdj
            g.DrawImage(img, rimage)
        End If
        Dim stringFormat As StringFormat = New StringFormat
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center
        Dim br As Brush
        Dim t As tshTabs = tabPage
        If t.isSaved Then
            br = Brushes.Black
        Else
            br = Brushes.Blue
        End If
        g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat)
    End Sub

    Private Sub tshTabControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        SelectedTab.Controls(0).Focus()
    End Sub
End Class
