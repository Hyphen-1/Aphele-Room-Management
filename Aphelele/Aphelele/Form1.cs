using static Aphelele.Form1;

namespace Aphelele
{
    public partial class Form1 : Form
    {
        private List<Room> rooms;
        private int nextRoomNumber = 1;

        public Form1()
        {
            InitializeComponent();
            rooms = new List<Room>();
            PrepopulateRooms(); 
        }

        private void PrepopulateRooms()
        {
          
            rooms.Add(new Room("Standard", 1, "Available"));
            rooms.Add(new Room("Deluxe", 2, "Booked"));
            rooms.Add(new Room("Suite", 4, "Available"));
            rooms.Add(new Room("Family", 4, "Available"));
            rooms.Add(new Room("Executive", 1, "Available"));
            rooms.Add(new Room("Accessible", 1, "Available"));
            rooms.Add(new Room("Penthouse", 2, "Booked"));

            foreach (var room in rooms)
            {
                dataGridView1.Rows.Add(nextRoomNumber++, room.RoomName, room.RoomType, room.RoomStatus);
            }
        }

       
        public class Room
        {
            public string RoomName { get; set; }
            public int RoomType { get; set; }
            public string RoomStatus { get; set; }

            public Room(string roomName, int roomType, string roomStatus)
            {
                RoomName = roomName;
                RoomType = roomType;
                RoomStatus = roomStatus;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Save button
        private void button2_Click(object sender, EventArgs e)
        {
            string roomName = textBox1.Text;
            int roomType = int.Parse(comboBox1.Text);
            string roomStatus = comboBox2.Text;

            Room newRoom = new Room(roomName, roomType, roomStatus);
            rooms.Add(newRoom);


            dataGridView1.Rows.Add(nextRoomNumber++, newRoom.RoomName, newRoom.RoomType, newRoom.RoomStatus);


            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
              
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

             

                
                int selectedIndex = selectedRow.Index;
                rooms.RemoveAt(selectedIndex);
                dataGridView1.Rows.RemoveAt(selectedIndex);
                UpdateRoomNumbers();
            }
        }

        private void UpdateRoomNumbers()
        {
            int roomNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = roomNumber++; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedIndex = selectedRow.Index;
                Room editedRoom = rooms[selectedIndex];

                editedRoom.RoomName = textBox1.Text;
                editedRoom.RoomType = int.Parse(comboBox1.Text);
                editedRoom.RoomStatus = comboBox2.Text;

                dataGridView1.Rows[selectedIndex].Cells[1].Value = editedRoom.RoomName;
                dataGridView1.Rows[selectedIndex].Cells[2].Value = editedRoom.RoomType;
                dataGridView1.Rows[selectedIndex].Cells[3].Value = editedRoom.RoomStatus;

                
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells[1].Value.ToString();
                comboBox1.Text = selectedRow.Cells[2].Value.ToString();
                comboBox2.Text = selectedRow.Cells[3].Value.ToString();

            }
        }
    }
}