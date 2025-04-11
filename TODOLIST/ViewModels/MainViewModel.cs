using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TODOLIST.Data;
using TODOLIST.Models;

namespace TODOLIST.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly TodoRepository _repository = new TodoRepository();

        private string _newTodoTitle;
        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set
            {
                _newTodoTitle = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TodoItem> Todos { get; set; } = new();

        public ICommand AddCommand { get; }

        public MainViewModel()
        {
            LoadTodos();
            AddCommand = new RelayCommand(AddTodo);
        }

        private void LoadTodos()
        {
            var todosFromDb = _repository.GetTodos();
            Todos.Clear();
            foreach (var todo in todosFromDb)
                Todos.Add(todo);
        }

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoTitle))
            {
                _repository.AddTodo(NewTodoTitle);
                NewTodoTitle = string.Empty;
                LoadTodos(); // 새로고침
            }
        }

        // === INotifyPropertyChanged 구현 ===
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
