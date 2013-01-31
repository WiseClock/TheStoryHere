Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions
Imports TheStoryHere.tshEditor.lang
Imports TheStoryHere.tshEditor.mode
Imports System.Linq

Friend Class tshEditor
    Inherits FastColoredTextBox

    Private vLangUsing As lang = TXT
    Private vModeUsing As mode = Note

    Private grayStyle As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Private quotesStyle As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
    Private numberStyle As TextStyle = New TextStyle(Brushes.DarkOrange, Nothing, FontStyle.Regular)
    Private majorStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Private minorStyle As TextStyle = New TextStyle(Brushes.DeepPink, Nothing, FontStyle.Regular)
    Private commentStyle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Private wrongStyle As TextStyle = New TextStyle(Brushes.Blue, Brushes.LightPink, FontStyle.Regular)

    Private SameWordsStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))
    Private functionStyle As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)

    Private WithEvents popupMenu As AutocompleteMenu = New AutocompleteMenu(Me) With {.SearchPattern = "[\w\.:=!<>]"}

    Enum lang
        C = 0
        Java = 1
        SQL = 2
        TXT = 3
    End Enum

    Enum mode
        Note = 0
        Assignment = 1
    End Enum

    Friend Sub New()
        ShowFoldingLines = True
        ImeMode = True
        AutoScrollMinSize = New Size(12, 15)
        BackBrush = Nothing
        BorderStyle = BorderStyle.None
        Cursor = Cursors.IBeam
        DisabledColor = Color.FromArgb(100, 180, 180, 180)
        Dock = DockStyle.Fill
        Font = New Font("Consolas", 12)
        LeftPadding = 15
        Location = New Point(0, 45)
        Name = "fctb"
        Paddings = New Padding(0)
        SelectionColor = Color.FromArgb(50, 0, 144, 255)
        ServiceLinesColor = Color.Gray
        ShowLineNumbers = False
        Size = New Size(361, 295)
        TabIndex = 4
        TabLength = 4
        AutoIndentExistingLines = True
        PreferredLineWidth = 80
        AutoIndent = True
        WordWrap = True
        WordWrapMode = FastColoredTextBoxNS.WordWrapMode.WordWrapControlWidth
        AddHandler TextChanged, New EventHandler(Of TextChangedEventArgs)(AddressOf Me._TextChanged)
        InitStylesPriority()
    End Sub

    Private Sub InitStylesPriority()
        AddStyle(SameWordsStyle)
    End Sub

    Private Sub _TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        e.ChangedRange.ClearFoldingMarkers()
        e.ChangedRange.ClearStyle(grayStyle, quotesStyle, numberStyle, majorStyle, minorStyle, commentStyle, wrongStyle)
        If langUsing = SQL Then
            SQLhighlight(e)
        ElseIf langUsing = Java Then
            Javahighlight(e)
        ElseIf langUsing = C Then
            Chighlight(e)
        End If
    End Sub

    Private Sub Chighlight(ByVal e As TextChangedEventArgs)
        Dim codeBlock As String = ".*"
        If modeUsing = Note Then
            codeBlock = "@code.*?(@endcode|$)"
        End If
        For Each r As FastColoredTextBoxNS.Range In GetRanges(codeBlock, RegexOptions.Singleline)
            r.SetFoldingMarkers("{", "}")
            r.SetFoldingMarkers("/\*", "\*/")
            r.SetFoldingMarkers("#ifndef\b", "#endif\b", RegexOptions.IgnoreCase)
            r.ClearStyle()
            If modeUsing = Note Then
                r.SetFoldingMarkers("@\bcode\b", "@\bendcode\b", RegexOptions.IgnoreCase)
                r.SetStyle(grayStyle, "@\b(code|endcode)\b", RegexOptions.IgnoreCase)
            End If
            'Comments
            r.SetStyle(commentStyle, "/\*.*?(\*/|$)", RegexOptions.Singleline)
            'Quotes
            r.SetStyle(quotesStyle, """.*?([^\\]""|$)|'.*?([^\\]'|$)", RegexOptions.Singleline)
            'Numbers
            r.SetStyle(numberStyle, "\b[0-9]+(\.[0-9]+?)?\b")
            'Operators
            ''r.SetStyle(majorStyle, "\/|\*|\,|\.|\=|\+|\-|\;|\>|\<|\(|\)|\{|\}|\[|\]|\!", RegexOptions.None)
            'Minor keywords
            Dim miKeywords As String = "auto|char|double|extern|float|int|long|register|short|static|typedef|" &
                                       "unsigned|enum|void|const|signed|volatile"
            'Major keywords
            Dim mKeywords As String = "break|case|continue|default|do|else|entry|for|goto|if|return|sizeof|struct|" &
                                      "switch|while"
            'Syntax
            r.SetStyle(majorStyle, "\b(" + mKeywords + ")\b", RegexOptions.IgnoreCase)
            r.SetStyle(minorStyle, "\b(" + miKeywords + ")\b", RegexOptions.IgnoreCase)
            r.SetStyle(quotesStyle, "^[ ]*?#.*", RegexOptions.Multiline)
        Next
    End Sub

    Private Sub Javahighlight(ByVal e As TextChangedEventArgs)
        Dim codeBlock As String = ".*"
        If modeUsing = Note Then
            codeBlock = "@code.*?(@endcode|$)"
        End If
        For Each r As FastColoredTextBoxNS.Range In GetRanges(codeBlock, RegexOptions.Singleline)
            r.SetFoldingMarkers("{", "}")
            r.SetFoldingMarkers("/\*", "\*/")
            r.ClearStyle()
            If modeUsing = Note Then
                r.SetFoldingMarkers("@\bcode\b", "@\bendcode\b", RegexOptions.IgnoreCase)
                r.SetStyle(grayStyle, "@\b(code|endcode)\b", RegexOptions.IgnoreCase)
            End If
            'Comments
            r.SetStyle(commentStyle, "/\*.*?(\*/|$)", RegexOptions.Singleline)
            r.SetStyle(commentStyle, "//.*", RegexOptions.Multiline)
            'Quotes
            r.SetStyle(quotesStyle, """.*?([^\\]""|$)|'.*?([^\\]'|$)", RegexOptions.Singleline)
            'Numbers
            r.SetStyle(numberStyle, "\b[0-9]+(\.[0-9]+?)?\b")
            'Operators
            ''r.SetStyle(majorStyle, "\/|\*|\,|\.|\=|\+|\-|\;|\>|\<|\(|\)|\{|\}|\[|\]|\!", RegexOptions.None)
            'Minor keywords
            Dim miKeywords As String = "boolean|byte|char|double|float|int|long|short|void"
            'Major keywords
            Dim mKeywords As String = "abstract|assert|break|case|catch|class|continue|default|" &
                                      "do|else|enum|extends|false|final|finally|for|if|implements|" &
                                      "import|instanceof|interface|native|new|null|package|private|" &
                                      "protected|public|return|static|strictfp|super|switch|sychronized|" &
                                      "this|throw|throws|transient|true|try|volatile|while"
            'Suspended keywords
            Dim sKeywords As String = "const|goto"
            'Correct syntax
            r.SetStyle(majorStyle, "\b(" + mKeywords + ")\b", RegexOptions.None)
            r.SetStyle(minorStyle, "\b(" + miKeywords + ")\b", RegexOptions.None)
            'Wrong syntax
            r.SetStyle(wrongStyle, "\b(" + sKeywords + ")\b", RegexOptions.None)
        Next
    End Sub

    Private Sub SQLhighlight(ByVal e As TextChangedEventArgs)
        Dim codeBlock As String = ".*"
        If modeUsing = Note Then
            codeBlock = "@code.*?(@endcode|$)"
        End If
        For Each r As FastColoredTextBoxNS.Range In GetRanges(codeBlock, RegexOptions.Singleline)
            'r.ClearStyle()
            If modeUsing = Note Then
                r.SetFoldingMarkers("@\bcode\b", "@\bendcode\b", RegexOptions.IgnoreCase)
                r.SetStyle(grayStyle, "@\b(code|endcode)\b", RegexOptions.IgnoreCase)
            End If
            'Comments
            r.SetStyle(commentStyle, "--.*$", RegexOptions.Multiline)
            'Quotes
            r.SetStyle(quotesStyle, "'.*?([^\\]'|$)", RegexOptions.Singleline)
            'Numbers
            r.SetStyle(numberStyle, "\b[0-9]+(\.[0-9]+?)?\b")
            'Operators
            ''r.SetStyle(majorStyle, "\/|\*|\,|\.|\=|\+|\-|\;|\>|\<|\(|\)", RegexOptions.None)
            r.SetStyle(majorStyle, "\,|\;|\(|\)", RegexOptions.None)
            'Minor keywords
            Dim miKeywords As String = "DATE|CHAR|VARCHAR|VARCHAR2|NUMBER|DECIMAL|FLOAT|INTEGER|LONG|SMALLINT"
            'Major keywords
            Dim mKeywords As String = "SELECT|FROM|WHERE|ORDER BY|GROUP BY|JOIN|ON|LEFT JOIN|RIGHT JOIN|FULL JOIN|" &
                                     "HAVING|SPOOL|ECHO|ON|OFF|ALTER|SESSION|SET|AND|UPDATE|" &
                                     "DROP|TABLE|CREATE|CONSTRAINT|DEFAULT|NULL|NOT|PRIMARY|FOREIGN|KEY|CHECK|" &
                                     "IN|BETWEEN|REFERENCES|INSERT|INTO|VALUES|ADD|" &
                                     "ACCESS|ALL|ANY|AS|ASC|DESC|AUDIT|BY|CLUSTER|COLUMN|HEADING|FORMAT|COMMENT|" &
                                     "COMPRESS|CONNECT|CURRENT|DELETE|DISTINCT|ELSE|EXCLUSIVE|EXISTS|FILE|FOR|" &
                                     "GRANT|GROUP|IDENTIFIED|IMMEDIATE|INCREMENT|INDEX|INITIAL|INTERSECT|IS|LEVEL|" &
                                     "LIKE|LOCK|SUM|COUNT|MAXETENTS|MINUS|MLSLABEL|MODE|MODIFY|NOAUDIT|NOCOMPRESS|" &
                                     "NOWAIT|OF|OFFLINE|ONLINE|OPTION|OR|ORDER|PCTFREE|PRIOR|PRIVILEGES|PUBLIC|RAW|" &
                                     "RENAME|RESOURCE|REVOKE|ROW|ROWID|ROWNUM|ROWS|SHARE|SIZE|START|SUCCESSFUL|" &
                                     "SYNONYM|SYSDATE|DUAL|THEN|TO|TRIGGER|UID|UNION|UNIQUE|USER|VALIDATE|VIEW|" &
                                     "WHENEVER|WITH|COMMIT"
            'Major keywords with underscores
            Dim mKeywordsNF As String = "TO_CHAR|TO_DATE"
            'Correct syntax
            r.SetStyle(majorStyle, "\b(" + mKeywords + ")\b", RegexOptions.None)
            r.SetStyle(majorStyle, "(" + mKeywordsNF + ")", RegexOptions.None)
            r.SetStyle(minorStyle, "\b(" + miKeywords + ")\b", RegexOptions.None)
            'Wrong syntax
            r.SetStyle(wrongStyle, "\b(" + mKeywords + ")\b", RegexOptions.IgnoreCase)
            r.SetStyle(wrongStyle, "(" + mKeywordsNF + ")", RegexOptions.IgnoreCase)
            r.SetStyle(wrongStyle, "\b(" + miKeywords + ")\b", RegexOptions.IgnoreCase)
            'Wrong quotes
            r.SetStyle(wrongStyle, """.*?([^\\]""|$)", RegexOptions.Singleline)
        Next
    End Sub

    Friend Property modeUsing() As mode
        Get
            Return vModeUsing
        End Get
        Set(ByVal v As mode)
            vModeUsing = v
            If v = Note Then
                Parent.Text = "N: " + Parent.Text.Substring(3, Parent.Text.Length - 3)
                ShowLineNumbers = False
            Else
                Parent.Text = "A: " + Parent.Text.Substring(3, Parent.Text.Length - 3)
                ShowLineNumbers = True
            End If
            OnTextChanged()
        End Set
    End Property

    Friend Property langUsing As lang
        Get
            Return vLangUsing
        End Get
        Set(ByVal v As lang)
            vLangUsing = v
            Select Case v
                Case SQL
                    CType(Parent, tshTabs).ImageIndex = 2
                    Dim keywords As String() = ("SELECT|FROM|WHERE|ORDER BY|GROUP BY|JOIN|ON|LEFT JOIN|RIGHT JOIN|FULL JOIN|" &
                                     "HAVING|SPOOL|ECHO|ON|OFF|ALTER|SESSION|SET|AND|UPDATE|" &
                                     "DROP|TABLE|CREATE|CONSTRAINT|DEFAULT|NULL|NOT|PRIMARY|FOREIGN|KEY|CHECK|" &
                                     "IN|BETWEEN|REFERENCES|INSERT|INTO|VALUES|ADD|" &
                                     "ACCESS|ALL|ANY|AS|ASC|DESC|AUDIT|BY|CLUSTER|COLUMN|HEADING|FORMAT|COMMENT|" &
                                     "COMPRESS|CONNECT|CURRENT|DELETE|DISTINCT|ELSE|EXCLUSIVE|EXISTS|FILE|FOR|" &
                                     "GRANT|GROUP|IDENTIFIED|IMMEDIATE|INCREMENT|INDEX|INITIAL|INTERSECT|IS|LEVEL|" &
                                     "LIKE|LOCK|MAXETENTS|MINUS|MLSLABEL|MODE|MODIFY|NOAUDIT|NOCOMPRESS|" &
                                     "NOWAIT|OF|OFFLINE|ONLINE|OPTION|OR|ORDER|PCTFREE|PRIOR|PRIVILEGES|PUBLIC|RAW|" &
                                     "RENAME|RESOURCE|REVOKE|ROW|ROWID|ROWNUM|ROWS|SHARE|SIZE|START|SUCCESSFUL|" &
                                     "SYNONYM|SYSDATE|DUAL|THEN|TO|TRIGGER|UID|UNION|UNIQUE|USER|VALIDATE|VIEW|" &
                                     "WHENEVER|WITH|COMMIT;").Split("|")
                    Dim snippets As String() = ("DATE(^)|CHAR(^)|VARCHAR(^)|VARCHAR2(^)|NUMBER(^)|NUMBER(^,)|" &
                                                "DECIMAL(^)|DECIMAL(^,)|FLOAT(^)|INTEGER(^)|LONG(^)|SMALLINT(^)|" &
                                                "TO_CHAR(^)|TO_DATE('^')|DATE('^')|SUM(^)|COUNT(^)").Split("|")


                    Dim items As New List(Of AutocompleteItem)()
                    For Each item As String In snippets
                        items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
                    Next
                    For Each item As String In keywords
                        items.Add(New AutocompleteItem(item))
                    Next
                    popupMenu.Items.SetAutocompleteItems(items)
                Case C
                    CType(Parent, tshTabs).ImageIndex = 0
                    Dim keywords As String() = ("auto|char|double|extern|float|int|long|register|short|static|typedef|" &
                                       "unsigned|enum|void|const|signed|volatile|break|case|continue|default|do|else|" &
                                       "entry|for|goto|if|return|sizeof|struct|switch|while|return 0;|" &
                                       "That's the story here.|Is it clear what I'm talking about?").Split("|")
                    Dim snippets As String() = ("include<^.h>|int main(^)|printf(^)|printf(""^"",)").Split("|")

                    Dim items As New List(Of AutocompleteItem)()
                    For Each item As String In snippets
                        items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
                    Next
                    For Each item As String In keywords
                        items.Add(New AutocompleteItem(item))
                    Next
                    popupMenu.Items.SetAutocompleteItems(items)
                Case Java
                    CType(Parent, tshTabs).ImageIndex = 1
                    Dim keywords As String() = ("boolean|byte|char|double|float|int|long|short|void|" &
                                      "abstract|assert|break|case|catch|class|continue|default|" &
                                      "do|else|enum|extends|false|final|finally|for|if|implements|" &
                                      "import|instanceof|interface|native|new|null|package|private|" &
                                      "protected|public|return|static|strictfp|super|switch|sychronized|" &
                                      "this|throw|throws|transient|true|try|volatile|while").Split("|")
                    Dim snippets As String() = ("public static void main(String[] args){^}").Split("|")
                    Dim methods As String() = ("System.out.print()|System.out.println()|System.exit()").Split("|")

                    Dim items As New List(Of AutocompleteItem)()
                    For Each item As String In snippets
                        items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
                    Next
                    For Each item As String In methods
                        items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
                    Next
                    For Each item As String In keywords
                        items.Add(New AutocompleteItem(item))
                    Next
                    popupMenu.Items.SetAutocompleteItems(items)
                Case Else
                    CType(Parent, tshTabs).ImageIndex = -1
            End Select
            OnTextChanged()
        End Set
    End Property

    Private Sub tshEditor_KeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPressed
        If CType(Parent, tshTabs).isSaved Then
            CType(Parent, tshTabs).isSaved = False
            If Parent IsNot Nothing AndAlso Parent.Parent IsNot Nothing Then
                Parent.Parent.Refresh()
            End If
        End If
    End Sub

    Private Sub tshEditor_SelectionChangedDelayed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChangedDelayed
        Range.ClearStyle(SameWordsStyle)
        If (Not Selection.IsEmpty) Or langUsing = TXT Then
            Return
        End If
        Dim fragment As Range = Selection.GetFragment("\w")
        Dim text As String = fragment.Text
        If (text.Length = 0) Then
            Return
        End If

        Dim codeBlock As String = ".*"
        If modeUsing = Note Then
            codeBlock = "@code.*?(@endcode|$)"
        End If
        For Each r As FastColoredTextBoxNS.Range In GetRanges(codeBlock, RegexOptions.Singleline)
            Dim ranges = r.GetRanges("\b" + text + "\b").ToArray
            If (ranges.Length > 1) Then
                For Each rr As Range In ranges
                    rr.SetStyle(SameWordsStyle)
                Next
            End If
        Next
    End Sub

    Private Sub tshEditor_TextChangedDelayed(ByVal sender As Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles Me.TextChangedDelayed
        Range.ClearStyle(functionStyle)
        If Not (langUsing = C Or langUsing = Java) Then
            Exit Sub
        End If
        Dim codeBlock As String = ".*"
        If modeUsing = Note Then
            codeBlock = "@code.*?(@endcode|$)"
        End If
        For Each r As FastColoredTextBoxNS.Range In GetRanges(codeBlock, RegexOptions.Singleline)
            Dim check As String = ""
            If langUsing = C Then
                check = "void|char|float|double|int|long|short|const"
            ElseIf langUsing = Java Then
                check = "boolean|byte|char|double|float|int|long|short|void|enum|class|String|Boolean|Byte|" &
                        "Char|Double|Float|Integer|Long|Short"
            End If
            For Each found As Range In r.GetRanges("\b(" + check + ")\s+(?<range>\w+)\b")
                Range.SetStyle(functionStyle, "\b" + found.Text + "\b")
            Next
        Next
    End Sub
End Class
