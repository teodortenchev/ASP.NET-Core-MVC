
# Forms

**Drop down from enum using HTML helper (no tag helper available yet)**

    <label asp-for="Type"></label>
    <select asp-for="Type" asp-items="@Html.GetEnumSelectList<EnumTypeHere>()">
    </select>


