﻿using TextControlBoxNS.Extensions;

namespace TextControlBoxNS.Core.Text;

internal class CurrentLineManager
{
    private CursorManager cursorManager;
    private TextManager textManager;

    public void Init(CursorManager cursorManager, TextManager textManager)
    {
        this.cursorManager = cursorManager;
        this.textManager = textManager;
    }

    public int CurrentLineIndex { get => cursorManager.currentCursorPosition.LineNumber; set => cursorManager.currentCursorPosition.LineNumber = value; }
    public string CurrentLine
    {
        get => GetCurrentLineText();
        set => SetCurrentLineText(value);
    }
    public int Length => textManager.totalLines.Count == 0 ? 0 : CurrentLine.Length;

    public string GetCurrentLineText()
    {
        return textManager.totalLines[CurrentLineIndex < textManager.LinesCount ? CurrentLineIndex : textManager.LinesCount - 1 < 0 ? 0 : textManager.LinesCount - 1];
    }
    public void SetCurrentLineText(string text)
    {
        textManager.totalLines[CurrentLineIndex < textManager.LinesCount ? CurrentLineIndex : textManager.LinesCount - 1] = text;
    }
    public void UpdateCurrentLine(int currentLine)
    {
        CurrentLineIndex = currentLine;
    }

    public void AddToEnd(string add)
    {
        CurrentLine = CurrentLine + add;
    }

    public void AddText(string add, int position)
    {
        if (position < 0)
            position = 0;

        if (position >= CurrentLine.Length || CurrentLine.Length <= 0)
            CurrentLine = CurrentLine + add;
        else
            CurrentLine = CurrentLine.Insert(position, add);
    }

    public void SafeRemove(int start, int count = -1)
    {
        CurrentLine = CurrentLine.SafeRemove(start, count);
    }
}
