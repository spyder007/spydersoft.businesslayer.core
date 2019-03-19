namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Used to indicate a action needed after a save has been executed
    /// </summary>
    public enum ResultActionType
    {
        None,
        Success,
        Error,
        Warning,
        PromptForAction, 
        Cancel
    }
}