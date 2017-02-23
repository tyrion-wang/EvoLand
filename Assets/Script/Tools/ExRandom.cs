public static class ExRandom {
	public static bool NextBool(this System.Random random)
	{
		return random.NextDouble() > 0.5;
	}
}
