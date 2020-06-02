using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame.Ogmo.Component
{
	public class OgmoMapGridLayer
	{
		public Point MapSize;
		public Point MapOffset;
		public OgmoGridLayer GridLayer;
		//public List<GridRectangle> Rectangles = new List<GridRectangle>();
		// key is Grid value at Ogmo
		public Dictionary<int, List<Rectangle>> Rectangles = new Dictionary<int, List<Rectangle>>(); 

		private int _xCount;
		
		public OgmoMapGridLayer(Point mapSize, Point mapOffset, OgmoGridLayer gridLayer)
		{
			MapSize = mapSize;
			MapOffset = mapOffset;
			GridLayer = gridLayer;
			_xCount = GridLayer.LayerDefinition.GridCellCount.X;
		}

		/// <summary>
		/// Minimalize the Grid, create a bunch of big rectangle
		/// </summary>
		private void BuildRectangle()
		{
			// mark the value as 0 to occupying it
			int[] GridOccupied = new int[GridLayer.Grid.Length];
			GridLayer.Grid.CopyTo(GridOccupied, 0);
			
			/*
			 * Requirement :
			 *   Start index
			 *   Current index
			 *   Current key
			 *
			 * How :
			 * Loop the grid copy
			 *  - if grid != 0
			 *    -> set current key = grid value
			 *    -> set start index
			 *    -> flag right and down = 1
			 *    -> set key = 0
			 *    -> set currentRightOffset and down = 1
			 *    -> start loop while (right != 0 and down != 0)
			 *       * if grid[sIndex + cRO + cDO] == key
			 *       * if grid[sIndex + cRO] == cKey
			 *          ** 
			 */
			
			for (int i = 0; i < GridLayer.Grid.Length; i++)
			{
				int val = GridLayer.Grid[i];
				Point xy = IndexConverter.IndexToXYByCount(i, _xCount);
				
				
			}
		}

		protected List<Rectangle> GetRectangleByKey(int key)
		{
			List<Rectangle> result;
			if (!Rectangles.TryGetValue(key, out result))
			{
				result = new List<Rectangle>();
				Rectangles.Add(key, result);
			}
			
			return result;
		}
	}

	public struct GridRectangle
	{
		public Rectangle Rectangle { get; }
		public int GridValue { get; }

		public GridRectangle(Rectangle rectangle, int gridValue)
		{
			Rectangle = rectangle;
			GridValue = gridValue;
		}
	}
}