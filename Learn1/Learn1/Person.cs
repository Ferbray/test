namespace Learn1;

public class Person
{
    public string Name = string.Empty;
}

public class Folder
{
    public string Name = string.Empty;
    public Folder? Parent;
    public FolderAccess[] Access = [];

    public bool HasReadAccess(Person person)
    {
        foreach (var access in Access)
        {
            if (access.Person.Name == person.Name && access.CanRead)
            {
                return true;
            }
        }

        return false;
    }

    public bool TryGetFolder(string name, out Folder? folder)
    {
        if (Name == name)
        {
            folder = this;
            return true;
        }
        
        if (Parent == null)
        {
            folder = null;
            return false;
        }
        
        return Parent.TryGetFolder(name, out folder);
    }
}

public class FolderAccess
{
    public Person Person = null!;
    
    public bool CanRead;
    public bool CanCreate;
    public bool CanUpdate;
    public bool CanDelete;
}

