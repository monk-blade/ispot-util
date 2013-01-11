Imports System.Xml
Imports System.Data
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists("C:\Users\ispot.xml") Then
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create("C:\Users\ispot.xml", New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)
            Dim i As Integer
            TextBox1.Text = ds.Tables(0).Rows(i).Item(0)
            TextBox2.Text = ds.Tables(0).Rows(i).Item(1)
            xmlFile.Close()
        End If
        


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
        
    End Sub

    Private Sub AboutDeveloperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutDeveloperToolStripMenuItem.Click
        MsgBox("Developed by Codejar Developer Community")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim writer As New XmlTextWriter("C:\Users\ispot.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("Table")
        createNode(TextBox1.Text, TextBox2.Text, writer)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
        Dim str1 As String
        Dim str2 As String
        Dim strf As String
        str1 = TextBox1.Text
        str2 = TextBox2.Text
        strf = "netsh wlan set hostednetwork mode=allow ssid=" + str1 + " key=" + str2
        Shell(strf)
        Shell("netsh wlan start hostednetwork")

        Exit Sub

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Shell("netsh wlan stop hostednetwork")
        Exit Sub
    End Sub
    Private Sub createNode(ByVal pID As String, ByVal pName As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("ispot")
        writer.WriteStartElement("wlan_id")
        writer.WriteString(pID)
        writer.WriteEndElement()
        writer.WriteStartElement("wlan_pass")
        writer.WriteString(pName)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ShareConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShareConnectionToolStripMenuItem.Click
        Dim oForm As Dialog1
        oForm = New Dialog1()
        oForm.Show()
        oForm = Nothing
    End Sub
End Class
