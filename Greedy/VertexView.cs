using System.Drawing;
using System.Windows.Forms;

namespace Greedy
{
	public class VertexView : PictureBox
	{
		public int Id { get; }
		public int X { get; }
		public int Y { get; }
		public new int Width { get; } = 20;
		public new int Height { get; } = 20;

		private bool _isSelected;
		private readonly Bitmap _pointImage;
		private readonly Bitmap _selectedPointImage;

		public VertexView(int x, int y, int id)
		{
			Name = id.ToString();
			Id = id;
			X = x - 10;
			Y = y - 10;
			Location = new Point(X, Y);
			ClientSize = new Size(Width, Height);
			SizeMode = PictureBoxSizeMode.StretchImage;
			
			_isSelected = false;
			_pointImage = new Bitmap(@"img\point.png");
			_selectedPointImage = new Bitmap(@"img\pointSelected.png");

			Image = _pointImage;
		}
		
		public void SetSelected(bool value)
		{
			_isSelected = value;
			Image = _isSelected ? _selectedPointImage : _pointImage;
		}
	}
}