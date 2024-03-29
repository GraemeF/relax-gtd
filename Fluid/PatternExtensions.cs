﻿using System.Windows.Automation;

namespace Fluid
{
    public static class PatternExtensions
    {
        public static string GetValue(this AutomationElement element)
        {
            var pattern = element.GetPattern<ValuePattern>(ValuePattern.Pattern);

            return pattern.Current.Value;
        }

        public static void SetValue(this AutomationElement element, string value)
        {
            var pattern = element.GetPattern<ValuePattern>(ValuePattern.Pattern);

            pattern.SetValue(value);
        }

        public static ScrollItemPattern GetScrollItemPattern(this AutomationElement element)
        {
            return element.GetPattern<ScrollItemPattern>(ScrollItemPattern.Pattern);
        }

        public static ValuePattern GetValuePattern(this AutomationElement element)
        {
            return element.GetPattern<ValuePattern>(ValuePattern.Pattern);
        }

        public static SelectionItemPattern GetSelectionItemPattern(this AutomationElement element)
        {
            return element.GetPattern<SelectionItemPattern>(SelectionItemPattern.Pattern);
        }

        public static SelectionPattern GetSelectionPattern(this AutomationElement element)
        {
            return element.GetPattern<SelectionPattern>(SelectionPattern.Pattern);
        }

        public static TogglePattern GetTogglePattern(this AutomationElement element)
        {
            return element.GetPattern<TogglePattern>(TogglePattern.Pattern);
        }

        public static ExpandCollapsePattern GetExpandCollapsePattern(this AutomationElement element)
        {
            return element.GetPattern<ExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
        }

        public static WindowPattern GetWindowPattern(this AutomationElement element)
        {
            return element.GetPattern<WindowPattern>(WindowPattern.Pattern);
        }

        public static InvokePattern GetInvokePattern(this AutomationElement element)
        {
            return element.GetPattern<InvokePattern>(InvokePattern.Pattern);
        }

        public static T GetPattern<T>(this AutomationElement element, AutomationPattern pattern) where T : class
        {
            object patternObject = element.GetCurrentPattern(pattern);

            return patternObject as T;
        }
    }
}