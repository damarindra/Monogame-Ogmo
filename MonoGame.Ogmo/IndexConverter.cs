using System;
using Microsoft.Xna.Framework;

namespace MonoGame.Ogmo
{
	public static class IndexConverter
	{
		public static Point IndexToXYByCount(int i, int XCount)
		{
			return new Point(i % XCount, (int)Math.Floor((double) i / XCount));
		}

		public static Vector2 ToVector(this Point p)
		{
			return new Vector2(p.X, p.Y);
		}
		public static Point ToPoint(this Vector2 p)
		{
			return new Point((int)p.X, (int)p.Y);
		}
	}
}