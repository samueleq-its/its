namespace Atleti
{
	internal interface IAtletaUniversale: IAtleta, INuotatore, ITennista
	{
		string Mangio();
		string Bevo();
	}
}
