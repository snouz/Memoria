﻿using System;

namespace FF9
{
	public class citem
	{
		public static Boolean YCITEM_IS_ITEM(Int32 a)
		{
			return a >= 224;
		}

		public static Boolean YCITEM_IS_THROW(Int32 a)
		{
			return a < 88 && (ff9weap.WeaponData[a].Category & 4) != 0;
		}
	}
}
