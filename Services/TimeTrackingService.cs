using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TimeTrackingService
{
    private List<TimeEntry> timeEntries;

    public TimeTrackingService()
    {
        LoadTimeEntriesFromFile();
    }

    private void LoadTimeEntriesFromFile()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "timeEntries.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            timeEntries = JsonConvert.DeserializeObject<List<TimeEntry>>(json);
        }
        else
        {
            timeEntries = new List<TimeEntry>();
        }
    }

    public void AddTimeEntry(TimeEntry entry)
    {
        timeEntries.Add(entry);
        SaveTimeEntriesToFile();
    }

    private void SaveTimeEntriesToFile()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "timeEntries.json");
        string json = JsonConvert.SerializeObject(timeEntries, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<TimeEntry> GetTimeEntries(int employeeId)
    {
        List<TimeEntry> result = new List<TimeEntry>();
        foreach (var entry in timeEntries)
        {
            if (entry.EmployeeId == employeeId)
            {
                result.Add(entry);
            }
        }
        List<TimeEntry> finalResult = new List<TimeEntry>();
        foreach (var entry in result)
        {
            finalResult.Add(entry);
        }
        return finalResult;
    }
}