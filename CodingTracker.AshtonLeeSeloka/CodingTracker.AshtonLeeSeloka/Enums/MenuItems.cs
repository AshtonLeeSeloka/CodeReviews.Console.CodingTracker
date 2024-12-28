namespace CodingTracker.AshtonLeeSeloka.Models;

public class MenuItems
{
    internal enum MenuOptions
    {
        View_Coding_Sessions,
        Insert_New_Session,
        Update_Coding_Session,
        Delete_Coding_Session,
        Generate_Report,
        End_Application
    }

    public enum MenuInsert
    {
        Manually_Record_Session,
		Start_Timer,
        Back
    }
}
