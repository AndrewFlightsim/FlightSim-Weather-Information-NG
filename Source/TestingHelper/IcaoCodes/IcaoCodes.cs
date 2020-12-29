// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System.Collections.Generic;

#endregion

namespace TestingHelper.IcaoCodes
{
    public static class IcaoCodes
    {
        public static readonly object[] CollectionsWithInvalidStringIcaoCodes =
        {
            new[] {new List<string> {"uUEE"}},
            new[] {new List<string> {"", " ", "E"}},
            new[] {new List<string> {"UUE_E", "1EDDF", "M2UHA"}},
            new[] {new List<string> {"UUErE", "EDDafF", "EDdDT", "%LOaWI"}}
        };

        public static readonly object[] CollectionsWithMixedValidAndInvalidStringIcaoCodes =
        {
            new[] {new List<string> {"UUEE", null}},
            new[] {new List<string> {"UMKK", "UUEe"}},
            new[] {new List<string> {"UUEE", "EDDF", "EDDF_"}},
            new[] {new List<string> {"UUE3", "EDDF12", " "}}
        };

        public static readonly object[] CollectionsWithValidStringIcaoCodes =
        {
            new[] {new List<string> {"UUEE"}},
            new[] {new List<string> {"UMKK", "UEEE", "EGLL"}},
            new[] {new List<string> {"UUEE", "EDDF", "MUHA"}},
            new[] {new List<string> {"UUEE", "EDDF", "EDDT", "LOWI"}}
        };

        public static readonly string[] InvalidStringIcaoCodesCollection =
        {
            null, "", " ", "KLaX", "_2340g", "UUEЁ", "%$#*", " UUEE"
        };

        public static readonly string[] ValidStringIcaoCodesCollection =
        {
            "UUEE", "EDDF", "EGLL", "KLAX", "KPHX", "MUHA"
        };
    }
}