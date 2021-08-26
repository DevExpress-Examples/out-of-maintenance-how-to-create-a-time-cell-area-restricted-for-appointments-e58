Namespace WindowsApplication1
    Public Class CustomResource
        Private m_name As String
        Private m_res_id As Integer
        Private m_PostCode As String
        Private m_Address As String

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property
        Public Property ResID() As Integer
            Get
                Return m_res_id
            End Get
            Set(ByVal value As Integer)
                m_res_id = value
            End Set
        End Property
        Public Property PostCode() As String
            Get
                Return m_PostCode
            End Get
            Set(ByVal value As String)
                m_PostCode = value
            End Set
        End Property
        Public Property Address() As String
            Get
                Return m_Address
            End Get
            Set(ByVal value As String)
                m_Address = value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class
End Namespace