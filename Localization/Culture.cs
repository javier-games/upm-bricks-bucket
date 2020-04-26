﻿using System.Globalization;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
#endif


// ReSharper disable InconsistentNaming
namespace BricksBucket.Localization
{
    /// <!-- Culture -->
    ///
    /// <summary>
    /// The Culture struct contains the basic information to categorize
    /// localizations by its language, country and/or region with the facility
    /// to use standards by the <see href="https://www.iso.org">
    /// International Organization for Standardization</see>.
    /// </summary>
    /// 
    /// <seealso cref="BricksBucket.Localization.LocalizationSettings"/>
    /// <seealso cref="BricksBucket.Localization.Book"/>
    /// 
    /// <!-- By Javier García | @jvrgms | 2020 -->
    [System.Serializable]
    public struct Culture
    {



        #region Fields

        /// <summary>
        /// Code to identify localizations related to this culture.
        /// </summary>
        [SerializeField]
        [Tooltip ("Code to identify language category.")]
        [OnValueChanged ("OnCodeChanged")]
        private string _code;

        /// <summary>
        /// Name of culture, useful to displays the culture instead fo its code.
        /// </summary>
        [SerializeField]
        [Tooltip ("Name for language category.")]
        private string _name;

        /// <summary>
        /// Windows Language Code Identifier. Defines the language and country
        /// of a culture using an standard available in all versions of Windows.
        /// More related information on <seealso href=
        /// "https://docs.microsoft.com/openspecs/windows_protocols/ms-lcid">
        /// MS-LCID</seealso> documentation.
        /// </summary>
        [SerializeField, EnumPaging]
        [Tooltip ("Windows Language Code Identifier.")]
        [OnValueChanged ("OnLCIDChanged")]
        private LCID _LCID;

        /// <summary>
        /// Language code from the <see href=
        /// "https://www.iso.org/iso-639-language-codes.html">ISO 639-1</see>
        /// standard.
        /// </summary>
        [SerializeField, EnumPaging]
        [Tooltip ("Language ISO-639 code.")]
        [OnValueChanged ("OnISOChanged")]
        private ISO639.Alpha1 _language;

        /// <summary>
        /// Country code from the <see href=
        /// "https://www.iso.org/iso-3166-country-codes.html">ISO 3166-2
        /// standard</see>.
        /// </summary>
        [SerializeField, EnumPaging]
        [Tooltip ("Country ISO-3166 code.")]
        [OnValueChanged ("OnISOChanged")]
        private ISO3166.Alpha2 _country;

        /// <summary>
        /// Specifies a region for the culture.
        /// </summary>
        [SerializeField]
        [Tooltip ("Specifies a region for the language.")]
        [OnValueChanged ("OnRegionChanged")]
        private string _region;

        /// <summary>
        /// Whether this culture is custom.
        /// </summary>
        [SerializeField]
        [Tooltip ("Whether this category is custom.")]
        [OnValueChanged ("OnIsCustomChanged")]
        private bool _isCustom;

        #endregion



        #region Properties

        /// <summary>
        /// Name of culture, useful to displays the culture instead of its code.
        /// Only editable on inspector.
        /// </summary>
        /// <returns>Name of the culture in the
        /// <c>Language (Country, Region)</c> format.</returns>
        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        /// <summary>
        /// Code to identify localizations related to this culture.
        /// Only editable on inspector.
        /// </summary>
        /// <returns>Code of the culture in <c>LANGUAGE_COUNTRY_REGION</c>
        /// format (e.g.<c>EN</c>, <c>EN_US</c>, <c>EN_US_WEST_COAST</c>).
        /// </returns>
        public string Code
        {
            get => _code;
            private set => _code = value;
        }

        /// <summary>
        /// Windows Language Code Identifier. Defines the language and country
        /// of a culture using an standard available in all versions of Windows.
        /// Only editable on inspector.
        /// </summary>
        /// <returns>Best match for the identifier. Returns <value><c>
        /// LCID.NONE</c></value> if there is not match for the language and
        /// country.</returns>
        /// <seealso href="../articles/localization/standard_lcid.html">
        /// Bricks Bucket LCID Table</seealso>
        /// <seealso href=
        /// "https://docs.microsoft.com/openspecs/windows_protocols/ms-lcid">
        /// Microsoft LCID Documentation</seealso>
        public LCID LCID
        {
            get => _LCID;
            private set => _LCID = value;
        }

        /// <summary>
        /// Language code from the <see href=
        /// "https://www.iso.org/iso-639-language-codes.html">ISO 639-1</see>
        /// standard. Only editable on inspector.
        /// </summary>
        /// <returns>Two letter code for languages. Returns <value><c>
        /// ISO639_1.NONE</c></value> if the culture has a custom language.
        /// </returns>
        /// <seealso href="../articles/localization/standard_iso639.html">
        /// Bricks Bucket ISO 639 Table</seealso>
        /// <!-- https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes -->
        public ISO639.Alpha1 Language
        {
            get => _isCustom ? ISO639.Alpha1.NONE : _language;
            private set => _language = value;
        }

        /// <summary>
        /// Country code from the <see href=
        /// "https://www.iso.org/iso-3166-country-codes.html">ISO 3166-2
        /// </see> standard. Only editable on inspector.
        /// </summary>
        /// <returns>Two letter code for countries.</returns>
        /// <seealso href="../articles/localization/standard_iso3166.html">
        /// Bricks Bucket ISO 3166 Table</seealso>
        /// <!-- https://en.wikipedia.org/wiki/ISO_3166-2 -->
        public ISO3166.Alpha2 Country
        {
            get => _country;
            private set => _country = value;
        }

        /// <summary>
        /// Region of the culture. An extra parameter when a deeper
        /// classification is needed. Only editable on inspector.
        /// </summary>
        /// <returns>Free optional format <see cref="string"/>.</returns>
        public string Region
        {
            get => _region;
            private set => _region = value;
        }

        /// <summary>
        /// Whether this culture is custom. When this property is true it is
        /// possible to define freely the name and code of the culture.
        /// </summary>
        /// <returns>Returns <value>true</value> if the culture is
        /// custom.</returns>
        public bool IsCustom
        {
            get => _isCustom;
            private set => _isCustom = value;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Called from inspector when an ISO code changed.
        /// </summary>
        private void OnISOChanged ()
        {
            if (IsCustom) return;

            LCID = LocalizationUtils.ToLCID (Language, Country);
            UpdateData ();
        }

        /// <summary>
        /// Called from inspector when LCID code changed.
        /// </summary>
        private void OnLCIDChanged ()
        {
            if (IsCustom) return;

            Country = (ISO3166.Alpha2) LocalizationUtils.ToISO3166 (LCID);
            Language = (ISO639.Alpha1) LocalizationUtils.ToISO639 (LCID);
            UpdateData ();
        }

        /// <summary>
        /// Called from inspector when the Region changes.
        /// </summary>
        private void OnRegionChanged ()
        {
            if (IsCustom) return;
            UpdateData ();
        }

        /// <summary>
        /// Called from inspector when the Code Changes.
        /// </summary>
        private void OnCodeChanged () => Code = Code.ToCodeFormat ();

        /// <summary>
        /// Called on is custom variable changes.
        /// </summary>
        private void OnIsCustomChanged ()
        {
            Name = string.Empty;
            Code = string.Empty;
            Country = ISO3166.Alpha2.NONE;
            Region = string.Empty;
            Language = ISO639.Alpha1.NONE;
            LCID = LCID.NONE;
        }

        /// <summary>
        /// Fetch all data.
        /// </summary>
        private void UpdateData ()
        {
            // It has a match for an LCID.
            if (LCID != LCID.NONE)
            {
                if (LCID == LCID.INVARIANT)
                {
                    Code = LCID.ToString ();
                    Name = "Invariant Language";
                }
                else
                {
                    var info = new CultureInfo ((int) LCID);
                    Code = info.Name.ToUpper ().Replace ("-", "_");
                    Name = info.DisplayName;

                    if (string.IsNullOrWhiteSpace (Region)) return;
                    Code = StringUtils.Concat (Code, "_", Region.ToUpper ());

                    if (Name.Contains (")"))
                    {
                        Name = Name.Replace (")", string.Empty);
                        Name = StringUtils.Concat (
                            Name, " - ", Region, ")"
                        );
                    }
                    else
                    {
                        Name = StringUtils.Concat (
                            Name, " (", Region, ")"
                        );
                    }
                }
            }

            // It has not a match for language and country.
            else
            {
                Code = Language.ToString ();
                Name = ISO639.Names[(int) Language];

                if (Country != ISO3166.Alpha2.NONE)
                {
                    Code = StringUtils.Concat (Code, "_", Country.ToString ());
                    Name = StringUtils.Concat (
                        Name, " (",
                        ISO3166.Names[(int) Country]
                    );
                }

                if (!string.IsNullOrWhiteSpace (Region))
                {
                    Code = StringUtils.Concat (Code, "_", Region.ToUpper ());

                    Name = Country == ISO3166.Alpha2.NONE
                        ? StringUtils.Concat (Name, " (", Region, ")")
                        : StringUtils.Concat (Name, " - ", Region, ")");
                }

                else if (Country != ISO3166.Alpha2.NONE)
                {
                    Name = StringUtils.Concat (Name, ")");
                }
            }
        }

        #endregion



        #region Editor

#if UNITY_EDITOR

        #region Drawer

        /// <summary>
        /// Language Category Drawer Class.
        /// </summary>
        public class LanguageCategoryDrawer : OdinValueDrawer<Culture>
        {

            #region Fields

            /// <summary>
            /// Whether the foldout is visible.
            /// </summary>
            private bool _isVisible;

            #endregion

            #region Override Methods

            /// <inheritdoc cref="OdinDrawer.DrawPropertyLayout"/>
            protected override void DrawPropertyLayout (GUIContent label)
            {
                var value = ValueEntry.SmartValue;

                //  Draws the label on Foldout.
                if (label != null)
                {
                    label.text = string.IsNullOrEmpty (label.text)
                        ? value.Code
                        : label.text;
                }
                else
                {
                    label = new GUIContent (value.Name, value.Code);
                }

                // Draws the fold out.
                _isVisible = SirenixEditorGUI.Foldout (
                    _isVisible,
                    label,
                    SirenixGUIStyles.Foldout
                );

                //  Draws content in fold out.
                if (_isVisible)
                {
                    EditorGUI.indentLevel++;
                    EditorGUI.indentLevel++;

                    var children = ValueEntry.Property.Children;

                    //  Draws LCID Options.
                    if (!value.IsCustom)
                    {
                        GUI.enabled = false;
                        EditorGUILayout.LabelField (
                            new GUIContent (
                                "Code", "Code to Identify language category."
                            ),
                            new GUIContent (value.Code),
                            EditorStyles.textField
                        );

                        EditorGUILayout.LabelField (
                            new GUIContent (
                                "Name", "Name for language category."
                            ),
                            new GUIContent (value.Name),
                            EditorStyles.textField
                        );
                        GUI.enabled = true;

                        children.Get ("_LCID").Draw ();
                        children.Get ("_language").Draw ();
                        children.Get ("_country").Draw ();
                        children.Get ("_region").Draw ();
                        children.Get ("_isCustom").Draw ();
                    }

                    //  Draws Custom options.
                    else
                    {
                        children.Get ("_code").Draw ();
                        children.Get ("_name").Draw ();
                        children.Get ("_country").Draw ();
                        children.Get ("_region").Draw ();
                        children.Get ("_isCustom").Draw ();
                    }

                    EditorGUI.indentLevel--;
                    EditorGUI.indentLevel--;
                }

                ValueEntry.SmartValue = value;
            }

            #endregion
        }

        /// <summary>
        /// Draws a Culture in the editor.
        /// </summary>
        /// <param name="culture">Culture to Draw.</param>
        /// <returns>Returns the edited culture value.</returns>
        public static Culture DrawEditorField (Culture culture)
        {
            if (!culture.IsCustom)
            {
                GUI.enabled = false;
                EditorGUILayout.LabelField (
                    new GUIContent (
                        "Code", "Code to Identify language category."
                    ),
                    new GUIContent (culture.Code),
                    EditorStyles.label
                );

                EditorGUILayout.LabelField (
                    new GUIContent (
                        "Name", "Name for language category."
                    ),
                    new GUIContent (culture.Name),
                    EditorStyles.label
                );
                GUI.enabled = true;

                EditorGUI.BeginChangeCheck ();
                culture.LCID = (LCID) SirenixEditorFields.EnumDropdown (
                    label: "LCID",
                    selected: culture.LCID
                );
                if (EditorGUI.EndChangeCheck ()) culture.OnLCIDChanged ();

                EditorGUI.BeginChangeCheck ();
                culture.Language =
                    (ISO639.Alpha1) SirenixEditorFields.EnumDropdown (
                        label: "Language",
                        selected: culture.Language
                    );
                if (EditorGUI.EndChangeCheck ()) culture.OnISOChanged ();

                EditorGUI.BeginChangeCheck ();
                culture.Country =
                    (ISO3166.Alpha2) SirenixEditorFields.EnumDropdown (
                        label: "Country",
                        selected: culture.Country
                    );
                if (EditorGUI.EndChangeCheck ()) culture.OnISOChanged ();

                EditorGUI.BeginChangeCheck ();
                culture.Region = SirenixEditorFields.TextField (
                    label: "Region",
                    value: culture.Region
                );
                if (EditorGUI.EndChangeCheck ()) culture.OnRegionChanged ();

                EditorGUI.BeginChangeCheck ();
                culture.IsCustom = EditorGUILayout.Toggle (
                    label: "Is Custom",
                    value: culture.IsCustom
                );
                if (EditorGUI.EndChangeCheck ()) culture.OnIsCustomChanged ();

            }

            //  Draws Custom options.
            else
            {
                EditorGUI.BeginChangeCheck ();
                culture.Code = SirenixEditorFields.TextField (
                    label: "Code",
                    value: culture.Code
                );
                if (EditorGUI.EndChangeCheck ()) culture.OnCodeChanged ();

                culture.Name = SirenixEditorFields.TextField (
                    label: "Name",
                    value: culture.Name
                );

                culture.Country =
                    (ISO3166.Alpha2) SirenixEditorFields.EnumDropdown (
                        label: "Country",
                        selected: culture.Country
                    );

                culture.Region = SirenixEditorFields.TextField (
                    label: "Region",
                    value: culture.Region
                );

                culture.IsCustom = EditorGUILayout.Toggle (
                    label: "Is Custom",
                    value: culture.IsCustom
                );
            }

            return culture;
        }

        #endregion

#endif

        #endregion
    }
}