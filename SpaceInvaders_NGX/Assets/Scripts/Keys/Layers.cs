// This class is auto-generated do not modify
namespace k
{
	public static class Layers
	{
		public const int DEFAULT = 0;
		public const int TRANSPARENT_FX = 1;
		public const int IGNORE_RAYCAST = 2;
		public const int WATER = 4;
		public const int UI = 5;
		public const int ENEMY_BULLET = 6;
		public const int ENEMY = 7;
		public const int PLAYER_BULLET = 8;
		public const int PLAYER = 9;


		public static int onlyIncluding( params int[] layers )
		{
			int mask = 0;
			for( var i = 0; i < layers.Length; i++ )
				mask |= ( 1 << layers[i] );
			return mask;
		}
		public static int everythingBut( params int[] layers )
		{
			return ~onlyIncluding( layers );
		}
	}
}