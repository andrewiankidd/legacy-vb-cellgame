
'expansion idea's/TODO
'loading maps is fine for now, once you have 3 or so maps make it so all maps are stored in the one .map file, split them with arrays as usual
'write out a rules list for creating worlds
'create an external program which can create maps
'warps should work by having another array, if the warp referes to towmmap,1,1 that means theres a warp at ycell1 xcell1



Public Class Form1
    Dim currentmapbg As String
    Dim cells(625) As String
    Dim spritecell As Integer
    Dim spritexcell As Integer
    Dim spriteycell As Integer
    Dim locx As Integer
    Dim locy As Integer
    Dim oktomove As Boolean
    Dim cellspecial As String
    Dim warps() As String
    Dim tempstring As String
    Dim devmode As Boolean = False
    Dim savestats(4) As String
    Dim curmap As String
    Dim found() As String
    Dim onaboat As Boolean = False
    Dim textpages() As String

    Public Sub loadmap(ByVal map As String)
        Dim objBitmap As New Bitmap(500, 500)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
        Dim mapbg As String


        Using reader As System.IO.StreamReader = New System.IO.StreamReader(map)
            cells = Split(Replace(reader.ReadToEnd, " ", vbNewLine), vbNewLine)
        End Using
        mapbg = Replace(map, System.IO.Path.GetFileNameWithoutExtension(map) & ".map", System.IO.Path.GetFileNameWithoutExtension(map) & ".jpg")
        curmap = System.IO.Path.GetFullPath(tempstring)
        warps = Split(cells(628), ":", -1)

        Me.Text = cells(0)
        currentmapbg = mapbg
        objGraphics.DrawImage(Image.FromFile(mapbg), 0, 0)
        pbGame.Image = objBitmap

        'spawn
        Dim spawn(1) As String
        spawn = Split(cells(626), ",")
        spawnsprite(spawn(0), spawn(1))
        spawnnpcs()

    End Sub
    'spawn main sprite
    Public Sub spawnsprite(ByVal spawnx As Integer, ByVal spawny As Integer)
        locx = spawnx
        locy = spawny

        Dim objBitmap As New Bitmap(500, 500)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
        If currentmapbg = "" Then
            'no map loaded
        Else
            objGraphics.DrawImage(Image.FromFile(currentmapbg), 0, 0)
        End If
        objGraphics.DrawImage(My.Resources.down, locx, locy)
        pbGame.Image = objBitmap
        getcell()
    End Sub
    'capturing keypress
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        Dim bhandled As Boolean
        Dim dir2send As String = ""
        Select Case keyData
            Case Keys.Up
                bhandled = True
                dir2send = "Up"
            Case Keys.Down
                bhandled = True
                dir2send = "Down"
            Case Keys.Left
                bhandled = True
                dir2send = "Left"
            Case Keys.Right
                bhandled = True
                dir2send = "Right"
            Case Keys.W
                bhandled = True
                dir2send = "Up"
            Case Keys.S
                bhandled = True
                dir2send = "Down"
            Case Keys.A
                bhandled = True
                dir2send = "Left"
            Case Keys.D
                bhandled = True
                dir2send = "Right"
            Case Keys.I
                bhandled = True
                If Inventory.Visible = True Then
                    Inventory.Visible = False
                Else
                    Inventory.Visible = True
                End If
        End Select
        gshowtext.Hide()
        printsprite(dir2send)
        Return bhandled
    End Function
    'recieve direction and move character
    Public Sub printsprite(ByVal direction As String)
        Dim objBitmap As New Bitmap(500, 500)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
        Dim directionimage As Image

        If currentmapbg = "" Then
            'no map loaded
        Else
            objGraphics.DrawImage(Image.FromFile(currentmapbg), 0, 0)
        End If

        If direction = "Left" Then
            runpcheck("Left")
            If oktomove = True Then
                locx = locx - 20
            End If
            directionimage = My.Resources.left
        ElseIf direction = "Right" Then
            runpcheck("Right")
            If oktomove = True Then
                locx = locx + 20
            End If
            directionimage = My.Resources.right
        ElseIf direction = "Up" Then
            runpcheck("Up")
            If oktomove = True Then
                locy = locy - 20
            End If
            directionimage = My.Resources.up
        ElseIf direction = "Down" Then
            runpcheck("Down")
            If oktomove = True Then
                locy = locy + 20
            End If
            directionimage = My.Resources.down
        Else
            'failsafe
            directionimage = My.Resources.down
        End If
        getcell()
        If onaboat = True Then
            directionimage = My.Resources.boat
        End If

        lbldebugdata.Text = direction & " realx: " & locx & " realy: " & locy & " virtualx: " & spritexcell & " virtualy: " & spriteycell & " Cell: " & spritecell

        objGraphics.DrawImage(directionimage, locx, locy)
        pbGame.Image = objBitmap

        If cellspecial = "" Then

        ElseIf cellspecial = "warp" Then
            getcell()
            warp(spritexcell, spriteycell)
            cellspecial = ""
        Else
            showtext(cellspecial)
            cellspecial = ""
        End If
        spawnnpcs()
    End Sub
    'find current cell number
    Public Sub getcell()
        Dim templocy As Integer = locy
        Dim templocx As Integer = locx

        For i = 1 To 25
            If templocy = 0 Then
                spriteycell = i
                Exit For
            Else
                templocy = templocy - 20
            End If
        Next i
        For i = 1 To 25
            If templocx = 0 Then
                spritexcell = i
                Exit For
            Else
                templocx = templocx - 20
            End If
        Next
        'add 25 onto the xcell number for every row it is above 
        spritecell = spritexcell + (spriteycell * 25) - 25
    End Sub
    'check cell permissions
    Public Sub runpcheck(ByVal direction As String)
        Dim futurecell As Integer
        onaboat = False
        If direction = "Up" Then
            futurecell = spritecell - 25
        ElseIf direction = "Down" Then
            futurecell = spritecell + 25
        ElseIf direction = "Left" Then
            futurecell = spritecell - 1
        ElseIf direction = "Right" Then
            futurecell = spritecell + 1
        End If

        If cells(futurecell) = 0 Then
            oktomove = True
        ElseIf cells(futurecell) = 1 Then
            oktomove = False
        ElseIf cells(futurecell) = 2 Then
            oktomove = True
            cellspecial = "warp"
        ElseIf cells(futurecell) = 3 Then
            cellspecial = "this door seems to be locked"
            oktomove = False
        ElseIf cells(futurecell) = 4 Then
            Try
                If inventorylist.FindItemWithText("small").Text.ToString = "small row boat" Then
                    cellspecial = "you get on a small boat"
                    oktomove = True
                    onaboat = True
                Else
                    cellspecial = "you can't swim!"
                    oktomove = False
                End If
            Catch
                cellspecial = "you can't swim!"
                oktomove = False
            End Try
        ElseIf cells(futurecell) = 5 Then
            oktomove = False
            Dim wasfound As Boolean = False
            found = Split(savestats(4), ":")
            For i = 0 To UBound(found)
                If found(i) = cells(0) Then
                    wasfound = True
                End If
            Next i
            If wasfound = True Then
                cellspecial = "The box is empty"
            ElseIf wasfound = False Then
                cells(630) = Replace(cells(630), "_", " ")
                cellspecial = "you found a " & cells(630)
                inventorylist.Items.Add(cells(630))
                savestats(4) = savestats(4) & cells(0) & ":"

            End If
        ElseIf cells(futurecell) = 6 Then
            Dim allnpctext() As String
            Dim npctext() As String
            allnpctext = Split(cells(632), ":")
            For i = 0 To UBound(allnpctext)
                npctext = Split(allnpctext(i), "=")
                ' npcimage = npctext(3)
                If futurecell.ToString = npctext(0) Then
                    showtext(Replace(npctext(1), "_", " "))
                End If
            Next i
            
            oktomove = False
        ElseIf cells(futurecell) = 7 Then
            'computer
            cellspecial = "A book"
            oktomove = False
        End If
        pbGame.SizeMode = PictureBoxSizeMode.StretchImage
        pbGame.Focus()
    End Sub
    'warping
    Public Sub warp(ByVal x As Integer, ByVal y As Integer)
        Dim temp() As String
        Dim t2(5) As String
        Dim x2 As Integer
        Dim y2 As Integer
        Dim newy As Integer
        Dim newx As Integer
        lbldebugdata.Text = x & " " & y

        temp = Split(cells(628), ":")
        For i = 0 To UBound(temp)
            t2 = Split(temp(i), ",")
            x2 = t2(1)
            y2 = t2(2)
            newx = t2(3)
            newy = t2(4)
            If t2(1) = x And t2(2) = y Then
                tempstring = Replace(open.FileName, System.IO.Path.GetFileNameWithoutExtension(open.FileName), t2(0))
                If tempstring.Contains(".world") Then
                    Dim fpath As String = IO.Path.GetFullPath(tempstring)
                    tempstring = Replace(fpath, System.IO.Path.GetFileNameWithoutExtension(fpath) & ".world", System.IO.Path.GetFileNameWithoutExtension(fpath) & ".map")
                Else
                End If



                loadmap(tempstring)
                spawnsprite(newx, newy)
                Exit For
            Else
            End If
        Next


    End Sub
    'initial setup
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("Press the help button for instructions and controls")
        Inventory.Hide()
        open.InitialDirectory = CurDir()
        gshowtext.Hide()


    End Sub
    'display an rpg-ish textbox
    Public Sub showtext(ByVal text As String)

        lblshowtext.Text = text
        gshowtext.Show()

    End Sub
    'save button
    Private Sub CMDsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDsave.Click
        savegame()
        pbGame.Focus()
    End Sub
    'load button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDloadsave.Click
        loadgame()
        pbGame.Focus()
    End Sub
    'save function
    Public Sub savegame()
        savestats(0) = "savestats"
        savestats(1) = curmap
        savestats(2) = locx
        savestats(3) = locy

        If IO.Directory.Exists("saves") = False Then
            IO.Directory.CreateDirectory("saves")
        Else
        End If

        IO.File.WriteAllLines("saves/save.sav", savestats)
        showtext("saved")

    End Sub
    'load function
    Public Sub loadgame()
        If IO.File.Exists("saves/save.sav") Then
            Dim file As String = IO.File.ReadAllText("saves/save.sav")
            showtext("load successful")
            savestats = Split(file, vbNewLine)

            open.FileName = savestats(1)
            tempstring = open.FileName
            loadmap(open.FileName)
            found = Split(savestats(4), ":")
            spawnsprite(savestats(2), savestats(3))
        Else
        End If
    End Sub
    'display help box
    Private Sub cmdhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdhelp.Click
        MsgBox("INSTRUCTIONS: PRESS OPEN, GO INTO MAP FOLDER AND OPEN THE .MAP FILE" & vbNewLine & vbNewLine & "CONTROLS: use direction keys to move, or WASD" & vbNewLine & "the I button will show your inventory" & vbNewLine & "any button will skip text")
        pbGame.Focus()
    End Sub



    'npc code

    Dim npccell, finalnpcx, finalnpcy, realnpcx, realnpcy As Integer
    Dim npcimage As Image = My.Resources.down
    'spawning
    Public Sub spawnnpcs()

        Dim npcspawn As Integer
        For i = 0 To 625
            If cells(i) = "6" Then
                npcspawn = i
                getxyfromcell(npcspawn)
                drawnpc(npcimage, finalnpcx - 1, finalnpcy - 1)
            Else
            End If
        Next i

    End Sub
    Public Sub getnpccell(ByVal npcx As Integer, ByVal npcy As Integer)
        npccell = npcx + ((npcy - 1) * 25)
    End Sub
 
    Public Sub getxyfromcell(ByVal cell As Integer)

        Dim x As Integer = cell
        Dim y As Integer
        Do
            x = x - 25
            y = y + 1
        Loop Until x < 25
        finalnpcx = x
        finalnpcy = y + 1
        '-1x2x10
        realnpcx = ((finalnpcx - 1) * 2) * 10
        realnpcy = ((finalnpcy - 1) * 2) * 10


    End Sub
    Public Sub drawnpc(ByVal image As Image, ByVal npcx As Integer, ByVal npcy As Integer)
        Dim objBitmap As New Bitmap(500, 500)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
      
        objGraphics.DrawImage(pbGame.Image, 0, 0)
        objGraphics.DrawImage(image, realnpcx, realnpcy)
        pbGame.Image = objBitmap

    End Sub
    Private Sub cmdopenworld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdopenworld.Click
        open.InitialDirectory = CurDir()
        open.ShowDialog()
        Dim mapname As String
        Dim mappath As String
        If IO.File.Exists(open.FileName) Then
            Using reader As System.IO.StreamReader = New System.IO.StreamReader(open.FileName)
                mapname = reader.ReadToEnd
            End Using
            tempstring = open.FileName
            mappath = Replace(IO.Path.GetFullPath(open.FileName), IO.Path.GetFileName(open.FileName), mapname)
            loadmap(mappath)
            tempstring = ""
            mappath = ""
        Else
            MsgBox("file not found")
        End If
        pbGame.Focus()
    End Sub
End Class