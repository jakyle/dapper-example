using Dapper;
using dappertutorial.DAL.Models;
using dappertutorial.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.DAL
{
    public interface ITodoDataStore : IInsertTodoItem, IUpdateTodoItem, IDeleteTodoItem, ISelectAllTodoItems, ISelectTodoItem
    {
    }
}
