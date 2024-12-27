namespace CodingTracker.AshtonLeeSeloka.Models;

internal class MenuItems
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

    internal enum MenuInsert
    {
        Start_Timer,
        Record_Previous_Session
    }
}
