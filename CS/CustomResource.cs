namespace WindowsApplication1 {
    public class CustomResource {
        private string m_name;
        private int m_res_id;
        private string m_PostCode;
        private string m_Address;

        public string Name { get { return m_name; } set { m_name = value; } }
        public int ResID { get { return m_res_id; } set { m_res_id = value; } }
        public string PostCode { get { return m_PostCode; } set { m_PostCode = value; } }
        public string Address { get { return m_Address; } set { m_Address = value; } }

        public CustomResource() {
        }
    }
}