using System.Threading.Tasks;
using dappertutorial.Models;

namespace dappertutorial.DAL
{
    public interface IInsertTodoItem
    {
        Task<int> InsertTodoItem(TodoItem todoItem);
    }
}