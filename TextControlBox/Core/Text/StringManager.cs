﻿using TextControlBoxNS.Helper;

namespace TextControlBoxNS.Core.Text
{
    internal class StringManager
    {
        private TextManager textManager;
        private TabSpaceHelper tabSpaceHelper;

        public void Init(TextManager textManager, TabSpaceHelper tabSpaceHelper)
        {
            this.textManager = textManager;
            this.tabSpaceHelper = tabSpaceHelper;
        }

        public string CleanUpString(string input)
        {
            //Fix tabs and lineendings
            return tabSpaceHelper.UpdateTabs(LineEndings.CleanLineEndings(input, textManager.LineEnding));
        }
    }
}
