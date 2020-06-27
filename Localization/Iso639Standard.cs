using System.Collections.Generic;
// ReSharper disable StringLiteralTypo

namespace BricksBucket.Localization
{
	// ISO 639 Part.
	// By Javier García | @jvrgms | 2020
	public static partial class Standards
	{
		/// <summary>
		/// Gets the name of the given ISO 639 enum value.
		/// </summary>
		/// <param name="language">ISO 639 to look for its name.</param>
		/// <returns>Empty if the ISO 639 value has not a name.</returns>
		public static string GetName (Iso639 language) =>
			Iso639Names.ContainsKey (language)
				? Iso639Names[language]
				: string.Empty;
		
		/// <summary>
		/// Gets the code of the given ISO 639 enum value.
		/// </summary>
		/// <param name="language">ISO 639 to look for its code.</param>
		/// <returns>Empty if the ISO 639 value has not a code.</returns>
		public static string GetCode (Iso639 language) =>
			System.Enum.IsDefined (typeof (Iso639), language)
				? language.ToString ().ToLower ()
				: string.Empty;

		/// <summary>
		/// Gets the ISO 639 enum value for the given string code.
		/// </summary>
		/// <param name="code">String value of the code of an ISO 639.</param>
		/// <returns><value>Iso639.NONE</value> if a code is not found.
		/// </returns>
		public static Iso639 GetIso639 (string code) =>
			System.Enum.TryParse (code, true, out Iso639 language)
				? language
				: Iso639.NONE;

		/// <summary>
		/// Gets the ISO 15924 enum value for the given ISO 639 code.
		/// </summary>
		/// <param name="language">ISO 639 to look for its script.</param>
		/// <returns><value>Iso15924.NONE</value> if a language has not a value.
		/// </returns>
		public static Iso15924 GetIso15924 (Iso639 language) =>
			Iso639Scripts.ContainsKey (language)
				? Iso639Scripts[language]
				: Iso15924.NONE;

		/// <summary>
		/// Gets the Plural Form for the given ISO 639 code.
		/// </summary>
		/// <param name="language">ISO 639 to look for its plural form.</param>
		/// <returns><value>Null</value> if the language has not a defined
		/// plural form.</returns>
		public static PluralForm GetPluralForm (Iso639 language) =>
			Iso639PluralForms.ContainsKey (language)
				? PluralForm.GetForm (Iso639PluralForms[language])
				: null;

		/// <summary>
		/// Dictionary of the names for ISO 639 enum members.
		/// </summary>
		private static readonly Dictionary<Iso639, string> Iso639Names =
			new Dictionary<Iso639, string>
			{
				{Iso639.NONE, "No Language"},
				{Iso639.AA, "Afar"},
				{Iso639.AB, "Abkhazian"},
				{Iso639.AE, "Avestan"},
				{Iso639.AF, "Afrikaans"},
				{Iso639.AK, "Akan"},
				{Iso639.AM, "Amharic"},
				{Iso639.AN, "Aragonese"},
				{Iso639.AR, "Arabic"},
				{Iso639.AS, "Assamese"},
				{Iso639.AV, "Avaric"},
				{Iso639.AY, "Aymara"},
				{Iso639.AZ, "Azerbaijani"},
				{Iso639.BA, "Bashkir"},
				{Iso639.BE, "Belarusian"},
				{Iso639.BG, "Bulgarian"},
				{Iso639.BH, "Bihari languages"},
				{Iso639.BI, "Bislama"},
				{Iso639.BM, "Bambara"},
				{Iso639.BN, "Bengali"},
				{Iso639.BO, "Tibetan"},
				{Iso639.BR, "Breton"},
				{Iso639.BS, "Bosnian"},
				{Iso639.CA, "Catalan"},
				{Iso639.CE, "Chechen"},
				{Iso639.CH, "Chamorro"},
				{Iso639.CO, "Corsican"},
				{Iso639.CR, "Cree"},
				{Iso639.CS, "Czech"},
				{Iso639.CU, "Old Church Slavonic"},
				{Iso639.CV, "Chuvash"},
				{Iso639.CY, "Welsh"},
				{Iso639.DA, "Danish"},
				{Iso639.DE, "German"},
				{Iso639.DV, "Divehi"},
				{Iso639.DZ, "Dzongkha"},
				{Iso639.EE, "Ewe"},
				{Iso639.EL, "Greek"},
				{Iso639.EN, "English"},
				{Iso639.EO, "Esperanto"},
				{Iso639.ES, "Spanish"},
				{Iso639.ET, "Estonian"},
				{Iso639.EU, "Basque"},
				{Iso639.FA, "Persian"},
				{Iso639.FF, "Fulah"},
				{Iso639.FI, "Finnish"},
				{Iso639.FJ, "Fijian"},
				{Iso639.FO, "Faroese"},
				{Iso639.FR, "French"},
				{Iso639.FY, "Western Frisian"},
				{Iso639.GA, "Irish"},
				{Iso639.GD, "Scottish Gaelic"},
				{Iso639.GL, "Galician"},
				{Iso639.GN, "Guarani"},
				{Iso639.GU, "Gujarati"},
				{Iso639.GV, "Manx"},
				{Iso639.HA, "Hausa"},
				{Iso639.HE, "Hebrew"},
				{Iso639.HI, "Hindi"},
				{Iso639.HO, "Hiri Motu"},
				{Iso639.HR, "Croatian"},
				{Iso639.HT, "Haitian Creole"},
				{Iso639.HU, "Hungarian"},
				{Iso639.HY, "Armenian"},
				{Iso639.HZ, "Herero"},
				{Iso639.IA, "Interlingua"},
				{Iso639.ID, "Indonesian"},
				{Iso639.IE, "Interlingue"},
				{Iso639.IG, "Igbo"},
				{Iso639.II, "Yi"},
				{Iso639.IK, "Inupiaq"},
				{Iso639.IO, "Ido"},
				{Iso639.IS, "Icelandic"},
				{Iso639.IT, "Italian"},
				{Iso639.IU, "Inuktitut"},
				{Iso639.JA, "Japanese"},
				{Iso639.JV, "Javanese"},
				{Iso639.KA, "Georgian"},
				{Iso639.KG, "Kongo"},
				{Iso639.KI, "Kikuyu"},
				{Iso639.KJ, "Kwanyama"},
				{Iso639.KK, "Kazakh"},
				{Iso639.KL, "Greenlandic"},
				{Iso639.KM, "Khmer"},
				{Iso639.KN, "Kannada"},
				{Iso639.KO, "Korean"},
				{Iso639.KR, "Kanuri"},
				{Iso639.KS, "Kashmiri"},
				{Iso639.KU, "Kurdish"},
				{Iso639.KV, "Komi"},
				{Iso639.KW, "Cornish"},
				{Iso639.KY, "Kyrgyz"},
				{Iso639.LA, "Latin"},
				{Iso639.LB, "Luxembourgish"},
				{Iso639.LG, "Ganda"},
				{Iso639.LI, "Limburgish"},
				{Iso639.LN, "Lingala"},
				{Iso639.LO, "Lao"},
				{Iso639.LT, "Lithuanian"},
				{Iso639.LU, "Luba-Katanga"},
				{Iso639.LV, "Latvian"},
				{Iso639.MG, "Malagasy"},
				{Iso639.MH, "Marshallese"},
				{Iso639.MI, "Maori"},
				{Iso639.MK, "Macedonian"},
				{Iso639.ML, "Malayalam"},
				{Iso639.MN, "Mongolian"},
				{Iso639.MR, "Marathi"},
				{Iso639.MS, "Malay"},
				{Iso639.MT, "Maltese"},
				{Iso639.MY, "Burmese"},
				{Iso639.NA, "Nauru"},
				{Iso639.NB, "Norwegian Bokmål"},
				{Iso639.ND, "North Ndebele"},
				{Iso639.NE, "Nepali"},
				{Iso639.NG, "Ndonga"},
				{Iso639.NL, "Dutch"},
				{Iso639.NN, "Norwegian Nynorsk"},
				{Iso639.NO, "Norwegian"},
				{Iso639.NR, "South Ndebele"},
				{Iso639.NV, "Navajo"},
				{Iso639.NY, "Chewa"},
				{Iso639.OC, "Occitan"},
				{Iso639.OJ, "Ojibwa"},
				{Iso639.OM, "Oromo"},
				{Iso639.OR, "Odia"},
				{Iso639.OS, "Ossetian"},
				{Iso639.PA, "Punjabi"},
				{Iso639.PI, "Pali"},
				{Iso639.PL, "Polish"},
				{Iso639.PS, "Pashto"},
				{Iso639.PT, "Portuguese"},
				{Iso639.QU, "Quechua"},
				{Iso639.RM, "Romansh"},
				{Iso639.RN, "Rundi"},
				{Iso639.RO, "Romanian"},
				{Iso639.RU, "Russian"},
				{Iso639.RW, "Kinyarwanda"},
				{Iso639.SA, "Sanskrit"},
				{Iso639.SC, "Sardinian"},
				{Iso639.SD, "Sindhi"},
				{Iso639.SE, "Northern Sami"},
				{Iso639.SG, "Sango"},
				{Iso639.SI, "Sinhala"},
				{Iso639.SK, "Slovak"},
				{Iso639.SL, "Slovenian"},
				{Iso639.SM, "Samoan"},
				{Iso639.SN, "Shona"},
				{Iso639.SO, "Somali"},
				{Iso639.SQ, "Albanian"},
				{Iso639.SR, "Serbian"},
				{Iso639.SS, "Swati"},
				{Iso639.ST, "Sotho"},
				{Iso639.SU, "Sundanese"},
				{Iso639.SV, "Swedish"},
				{Iso639.SW, "Swahili"},
				{Iso639.TA, "Tamil"},
				{Iso639.TE, "Telugu"},
				{Iso639.TG, "Tajik"},
				{Iso639.TH, "Thai"},
				{Iso639.TI, "Tigrinya"},
				{Iso639.TK, "Turkmen"},
				{Iso639.TL, "Tagalog"},
				{Iso639.TN, "Tswana"},
				{Iso639.TO, "Tongan"},
				{Iso639.TR, "Turkish"},
				{Iso639.TS, "Tsonga"},
				{Iso639.TT, "Tatar"},
				{Iso639.TW, "Twi"},
				{Iso639.TY, "Tahitian"},
				{Iso639.UG, "Uyghur"},
				{Iso639.UK, "Ukrainian"},
				{Iso639.UR, "Urdu"},
				{Iso639.UZ, "Uzbek"},
				{Iso639.VE, "Venda"},
				{Iso639.VI, "Vietnamese"},
				{Iso639.VO, "Volapük"},
				{Iso639.WA, "Walloon"},
				{Iso639.WO, "Wolof"},
				{Iso639.XH, "Xhosa"},
				{Iso639.YI, "Yiddish"},
				{Iso639.YO, "Yoruba"},
				{Iso639.ZA, "Zhuang"},
				{Iso639.ZH, "Chinese"},
				{Iso639.ZU, "Zulu"},
			};
		
		/// <summary>
		/// Dictionary of the Plural Forms for ISO 639 enum members.
		/// </summary>
        private static readonly Dictionary<Iso639, int> Iso639PluralForms =
            new Dictionary<Iso639, int>
            {
                {Iso639.NONE, 0x000},
                {Iso639.AF, 0x000},
                {Iso639.AK, 0x000},
                {Iso639.AM, 0x000},
                {Iso639.AN, 0x000},
                {Iso639.AR, 0x010},
                {Iso639.AS, 0x000},
                {Iso639.AY, 0x001},
                {Iso639.AZ, 0x000},
                {Iso639.BE, 0x002},
                {Iso639.BG, 0x000},
                {Iso639.BN, 0x000},
                {Iso639.BO, 0x001},
                {Iso639.BR, 0x000},
                {Iso639.BS, 0x002},
                {Iso639.CA, 0x000},
                {Iso639.CS, 0x003},
                {Iso639.CY, 0x00D},
                {Iso639.DA, 0x000},
                {Iso639.DE, 0x000},
                {Iso639.DZ, 0x001},
                {Iso639.EL, 0x000},
                {Iso639.EN, 0x000},
                {Iso639.EO, 0x000},
                {Iso639.ES, 0x000},
                {Iso639.ET, 0x000},
                {Iso639.EU, 0x000},
                {Iso639.FA, 0x000},
                {Iso639.FF, 0x000},
                {Iso639.FI, 0x000},
                {Iso639.FO, 0x000},
                {Iso639.FR, 0x000},
                {Iso639.FY, 0x000},
                {Iso639.GA, 0x00F},
                {Iso639.GD, 0x00C},
                {Iso639.GL, 0x000},
                {Iso639.GU, 0x000},
                {Iso639.HA, 0x000},
                {Iso639.HE, 0x000},
                {Iso639.HI, 0x000},
                {Iso639.HR, 0x002},
                {Iso639.HU, 0x000},
                {Iso639.HY, 0x000},
                {Iso639.IA, 0x000},
                {Iso639.ID, 0x001},
                {Iso639.IS, 0x005},
                {Iso639.IT, 0x000},
                {Iso639.JA, 0x001},
                {Iso639.JV, 0x000},
                {Iso639.KA, 0x001},
                {Iso639.KK, 0x000},
                {Iso639.KL, 0x000},
                {Iso639.KM, 0x001},
                {Iso639.KN, 0x000},
                {Iso639.KO, 0x001},
                {Iso639.KU, 0x000},
                {Iso639.KW, 0x00E},
                {Iso639.KY, 0x000},
                {Iso639.LB, 0x000},
                {Iso639.LN, 0x000},
                {Iso639.LO, 0x001},
                {Iso639.LT, 0x007},
                {Iso639.LV, 0x006},
                {Iso639.MG, 0x000},
                {Iso639.MI, 0x000},
                {Iso639.MK, 0x004},
                {Iso639.ML, 0x000},
                {Iso639.MN, 0x000},
                {Iso639.MR, 0x000},
                {Iso639.MS, 0x001},
                {Iso639.MT, 0x00B},
                {Iso639.MY, 0x001},
                {Iso639.NB, 0x000},
                {Iso639.NE, 0x000},
                {Iso639.NL, 0x000},
                {Iso639.NN, 0x000},
                {Iso639.NO, 0x000},
                {Iso639.OC, 0x000},
                {Iso639.OR, 0x000},
                {Iso639.PA, 0x000},
                {Iso639.PL, 0x009},
                {Iso639.PS, 0x000},
                {Iso639.PT, 0x000},
                {Iso639.RM, 0x000},
                {Iso639.RO, 0x008},
                {Iso639.RU, 0x002},
                {Iso639.RW, 0x000},
                {Iso639.SD, 0x000},
                {Iso639.SE, 0x000},
                {Iso639.SI, 0x000},
                {Iso639.SK, 0x003},
                {Iso639.SL, 0x00A},
                {Iso639.SO, 0x000},
                {Iso639.SQ, 0x000},
                {Iso639.SR, 0x002},
                {Iso639.SU, 0x001},
                {Iso639.SV, 0x000},
                {Iso639.SW, 0x000},
                {Iso639.TA, 0x000},
                {Iso639.TE, 0x000},
                {Iso639.TG, 0x000},
                {Iso639.TH, 0x001},
                {Iso639.TI, 0x000},
                {Iso639.TK, 0x000},
                {Iso639.TR, 0x000},
                {Iso639.TT, 0x001},
                {Iso639.UG, 0x001},
                {Iso639.UK, 0x002},
                {Iso639.UR, 0x000},
                {Iso639.UZ, 0x000},
                {Iso639.VI, 0x001},
                {Iso639.WA, 0x000},
                {Iso639.WO, 0x001},
                {Iso639.YO, 0x000},
                {Iso639.ZH, 0x001},
            };

		/// <summary>
		/// Dictionary of the ISO 15924 for ISO 639 enum members.
		/// </summary>
		public static readonly Dictionary<Iso639, Iso15924> Iso639Scripts =
			new Dictionary<Iso639, Iso15924>
			{
				{Iso639.NONE, Iso15924.NONE},
				{Iso639.AA, Iso15924.LATN},
				{Iso639.AB, Iso15924.CYRL},
				{Iso639.AE, Iso15924.AVST},
				{Iso639.AF, Iso15924.LATN},
				{Iso639.AK, Iso15924.LATN},
				{Iso639.AM, Iso15924.ETHI},
				{Iso639.AN, Iso15924.LATN},
				{Iso639.AR, Iso15924.ARAB},
				{Iso639.AS, Iso15924.BENG},
				{Iso639.AV, Iso15924.CYRL},
				{Iso639.AY, Iso15924.LATN},
				{Iso639.AZ, Iso15924.LATN},
				{Iso639.BA, Iso15924.CYRL},
				{Iso639.BE, Iso15924.CYRL},
				{Iso639.BG, Iso15924.CYRL},
				{Iso639.BH, Iso15924.DEVA},
				{Iso639.BI, Iso15924.LATN},
				{Iso639.BM, Iso15924.LATN},
				{Iso639.BN, Iso15924.BENG},
				{Iso639.BO, Iso15924.TIBT},
				{Iso639.BR, Iso15924.LATN},
				{Iso639.BS, Iso15924.LATN},
				{Iso639.CA, Iso15924.LATN},
				{Iso639.CE, Iso15924.CYRL},
				{Iso639.CH, Iso15924.LATN},
				{Iso639.CO, Iso15924.LATN},
				{Iso639.CR, Iso15924.CANS},
				{Iso639.CS, Iso15924.LATN},
				{Iso639.CU, Iso15924.CYRL},
				{Iso639.CV, Iso15924.CYRL},
				{Iso639.CY, Iso15924.LATN},
				{Iso639.DA, Iso15924.LATN},
				{Iso639.DE, Iso15924.LATN},
				{Iso639.DV, Iso15924.THAA},
				{Iso639.DZ, Iso15924.TIBT},
				{Iso639.EE, Iso15924.LATN},
				{Iso639.EL, Iso15924.GREK},
				{Iso639.EN, Iso15924.LATN},
				{Iso639.EO, Iso15924.LATN},
				{Iso639.ES, Iso15924.LATN},
				{Iso639.ET, Iso15924.LATN},
				{Iso639.EU, Iso15924.LATN},
				{Iso639.FA, Iso15924.ARAB},
				{Iso639.FF, Iso15924.LATN},
				{Iso639.FI, Iso15924.LATN},
				{Iso639.FJ, Iso15924.LATN},
				{Iso639.FO, Iso15924.LATN},
				{Iso639.FR, Iso15924.LATN},
				{Iso639.FY, Iso15924.LATN},
				{Iso639.GA, Iso15924.LATN},
				{Iso639.GD, Iso15924.LATN},
				{Iso639.GL, Iso15924.LATN},
				{Iso639.GN, Iso15924.LATN},
				{Iso639.GU, Iso15924.GUJR},
				{Iso639.GV, Iso15924.LATN},
				{Iso639.HA, Iso15924.ARAB},
				{Iso639.HE, Iso15924.HEBR},
				{Iso639.HI, Iso15924.DEVA},
				{Iso639.HO, Iso15924.LATN},
				{Iso639.HR, Iso15924.LATN},
				{Iso639.HT, Iso15924.LATN},
				{Iso639.HU, Iso15924.LATN},
				{Iso639.HY, Iso15924.ARMN},
				{Iso639.HZ, Iso15924.LATN},
				{Iso639.IA, Iso15924.LATN},
				{Iso639.ID, Iso15924.LATN},
				{Iso639.IE, Iso15924.LATN},
				{Iso639.IG, Iso15924.LATN},
				{Iso639.II, Iso15924.YIII},
				{Iso639.IK, Iso15924.LATN},
				{Iso639.IO, Iso15924.LATN},
				{Iso639.IS, Iso15924.LATN},
				{Iso639.IT, Iso15924.LATN},
				{Iso639.IU, Iso15924.CANS},
				{Iso639.JA, Iso15924.JPAN},
				{Iso639.JV, Iso15924.JAVA},
				{Iso639.KA, Iso15924.GEOR},
				{Iso639.KG, Iso15924.LATN},
				{Iso639.KI, Iso15924.LATN},
				{Iso639.KJ, Iso15924.LATN},
				{Iso639.KK, Iso15924.CYRL},
				{Iso639.KL, Iso15924.LATN},
				{Iso639.KM, Iso15924.KHMR},
				{Iso639.KN, Iso15924.KNDA},
				{Iso639.KO, Iso15924.KORE},
				{Iso639.KR, Iso15924.LATN},
				{Iso639.KS, Iso15924.ARAB},
				{Iso639.KU, Iso15924.LATN},
				{Iso639.KV, Iso15924.CYRL},
				{Iso639.KW, Iso15924.LATN},
				{Iso639.KY, Iso15924.CYRL},
				{Iso639.LA, Iso15924.LATN},
				{Iso639.LB, Iso15924.LATN},
				{Iso639.LG, Iso15924.LATN},
				{Iso639.LI, Iso15924.LATN},
				{Iso639.LN, Iso15924.LATN},
				{Iso639.LO, Iso15924.LAOO},
				{Iso639.LT, Iso15924.LATN},
				{Iso639.LU, Iso15924.LATN},
				{Iso639.LV, Iso15924.LATN},
				{Iso639.MG, Iso15924.LATN},
				{Iso639.MH, Iso15924.LATN},
				{Iso639.MI, Iso15924.LATN},
				{Iso639.MK, Iso15924.CYRL},
				{Iso639.ML, Iso15924.MLYM},
				{Iso639.MN, Iso15924.CYRL},
				{Iso639.MR, Iso15924.DEVA},
				{Iso639.MS, Iso15924.LATN},
				{Iso639.MT, Iso15924.LATN},
				{Iso639.MY, Iso15924.MYMR},
				{Iso639.NA, Iso15924.LATN},
				{Iso639.NB, Iso15924.LATN},
				{Iso639.ND, Iso15924.LATN},
				{Iso639.NE, Iso15924.DEVA},
				{Iso639.NG, Iso15924.LATN},
				{Iso639.NL, Iso15924.LATN},
				{Iso639.NN, Iso15924.LATN},
				{Iso639.NO, Iso15924.LATN},
				{Iso639.NR, Iso15924.LATN},
				{Iso639.NV, Iso15924.LATN},
				{Iso639.NY, Iso15924.LATN},
				{Iso639.OC, Iso15924.LATN},
				{Iso639.OJ, Iso15924.CANS},
				{Iso639.OM, Iso15924.LATN},
				{Iso639.OR, Iso15924.ORYA},
				{Iso639.OS, Iso15924.CYRL},
				{Iso639.PA, Iso15924.GURU},
				{Iso639.PI, Iso15924.DEVA},
				{Iso639.PL, Iso15924.LATN},
				{Iso639.PS, Iso15924.ARAB},
				{Iso639.PT, Iso15924.LATN},
				{Iso639.QU, Iso15924.LATN},
				{Iso639.RM, Iso15924.LATN},
				{Iso639.RN, Iso15924.LATN},
				{Iso639.RO, Iso15924.LATN},
				{Iso639.RU, Iso15924.CYRL},
				{Iso639.RW, Iso15924.LATN},
				{Iso639.SA, Iso15924.DEVA},
				{Iso639.SC, Iso15924.LATN},
				{Iso639.SD, Iso15924.ARAB},
				{Iso639.SE, Iso15924.LATN},
				{Iso639.SG, Iso15924.LATN},
				{Iso639.SI, Iso15924.SINH},
				{Iso639.SK, Iso15924.LATN},
				{Iso639.SL, Iso15924.LATN},
				{Iso639.SM, Iso15924.LATN},
				{Iso639.SN, Iso15924.LATN},
				{Iso639.SO, Iso15924.LATN},
				{Iso639.SQ, Iso15924.LATN},
				{Iso639.SR, Iso15924.CYRL},
				{Iso639.SS, Iso15924.LATN},
				{Iso639.ST, Iso15924.LATN},
				{Iso639.SU, Iso15924.LATN},
				{Iso639.SV, Iso15924.LATN},
				{Iso639.SW, Iso15924.LATN},
				{Iso639.TA, Iso15924.TAML},
				{Iso639.TE, Iso15924.TELU},
				{Iso639.TG, Iso15924.CYRL},
				{Iso639.TH, Iso15924.THAI},
				{Iso639.TI, Iso15924.ETHI},
				{Iso639.TK, Iso15924.LATN},
				{Iso639.TL, Iso15924.LATN},
				{Iso639.TN, Iso15924.LATN},
				{Iso639.TO, Iso15924.LATN},
				{Iso639.TR, Iso15924.LATN},
				{Iso639.TS, Iso15924.LATN},
				{Iso639.TT, Iso15924.CYRL},
				{Iso639.TW, Iso15924.LATN},
				{Iso639.TY, Iso15924.LATN},
				{Iso639.UG, Iso15924.ARAB},
				{Iso639.UK, Iso15924.CYRL},
				{Iso639.UR, Iso15924.ARAN},
				{Iso639.UZ, Iso15924.LATN},
				{Iso639.VE, Iso15924.LATN},
				{Iso639.VI, Iso15924.LATN},
				{Iso639.VO, Iso15924.LATN},
				{Iso639.WA, Iso15924.LATN},
				{Iso639.WO, Iso15924.LATN},
				{Iso639.XH, Iso15924.LATN},
				{Iso639.YI, Iso15924.HEBR},
				{Iso639.YO, Iso15924.LATN},
				{Iso639.ZA, Iso15924.LATN},
				{Iso639.ZH, Iso15924.HANS},
				{Iso639.ZU, Iso15924.LATN},
			};
	}
}