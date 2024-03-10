Imports System.ComponentModel.Design.Serialization
Imports System.Data.SqlClient



Public Class Form1
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id As Integer = TextBox1.Text
        Dim FIRSTNAME As String = TextBox2.Text
        Dim LASTNAME As String = TextBox3.Text
        Dim GENDER As String = ComboBox1.SelectedItem

        Dim query As String = "INSERT INTO [Table] VALUES(@ID, @FIRSTNAME, @LASTNAME, @GENDER)"
        Using con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HARSHIL\Documents\crud.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@FIRSTNAME", FIRSTNAME)
                cmd.Parameters.AddWithValue("@LASTNAME", LASTNAME)
                cmd.Parameters.AddWithValue("@GENDER", GENDER)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                MessageBox.Show("Successfully Inserted")
                BindData()


            End Using
        End Using
    End Sub
    Public Sub BindData()
        Dim query As String = "SELECT * FROM [Table]"
        Using con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HARSHIL\Documents\crud.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt

                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "SELECT * FROM [Table] WHERE ID = '" & TextBox4.Text & "'"
        Using con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HARSHIL\Documents\crud.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            TextBox1.Text = dt.Rows(0)(0).ToString()
                            TextBox2.Text = dt.Rows(0)(1).ToString()
                            TextBox3.Text = dt.Rows(0)(2).ToString()
                            ComboBox1.Text = dt.Rows(0)(3).ToString()
                        Else
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                            TextBox3.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim id As Integer = TextBox1.Text
        Dim FIRSTNAME As String = TextBox2.Text
        Dim LASTNAME As String = TextBox3.Text
        Dim GENDER As String = ComboBox1.SelectedItem

        Dim query As String = "UPDATE [Table] SET FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, GENDER = @GENDER WHERE ID = @ID"
        Using con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HARSHIL\Documents\crud.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@FIRSTNAME", FIRSTNAME)
                cmd.Parameters.AddWithValue("@LASTNAME", LASTNAME)
                cmd.Parameters.AddWithValue("@GENDER", GENDER)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                MessageBox.Show("Successfully Updated")
                BindData()


            End Using
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim id As Integer = TextBox1.Text
        Dim query As String = "DELETE FROM [Table] WHERE ID = @ID"
        Using con As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HARSHIL\Documents\crud.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ID", id)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                MessageBox.Show("Successfully Deleted")
                BindData()


            End Using
        End Using
    End Sub
End Class
