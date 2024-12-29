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

    public enum MenuReport 
    {
        Specify_Report_Range,
        View_All_Data,
        Back
    }

    public enum MenuViewData 
    {
        View_in_ascending_order,
        View_in_descending_order,
        Back
    
    }

	public enum MenuDescending
	{
		View_in_ascending_order,
		Back
	}

	public enum MenuAscending
	{
		View_in_descending_order,
		Back
	}
}
