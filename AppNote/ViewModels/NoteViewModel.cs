using AppNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppNote.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        //Fields
        private string _noteTitle;
        private string _noteDescription;
        private Note _selectedNote;

        //Get and Set
        public string NoteTitle
        {
            get => _noteTitle;
            set
            {
                if (_noteTitle != value)
                {
                    _noteTitle = value;
                    OnPropertyChanged();

                }
            }
        }

        public string NoteDescription
        {
            get => _noteDescription;
            set
            {
                if (_noteDescription != value)
                {
                    _noteDescription = value;
                    OnPropertyChanged();

                }
            }
        }

        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                if (_selectedNote != value)
                {
                    _selectedNote = value;
                    OnPropertyChanged();
                }
            }
        }

        //Property
        public ObservableCollection<Note> NoteCllection { get; set; }
        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

        public NoteViewModel()
        {
            NoteCllection = new ObservableCollection<Note>();
            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(DeletNote);
        }

        private void DeletNote(object obj)
        {
            if(SelectedNote!= null)
            {
                NoteCllection.Remove(SelectedNote);
                // Rest Values
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }

        private void AddNote(object obj)
        {
            int newId = NoteCllection.Count > 0 ? NoteCllection.Max(x => x.Id) + 1 : 1;
            // Set new note
            var note = new Note
            {
                Id = newId,
                Title = NoteTitle,
                Description = NoteDescription,
            };
            NoteCllection.Add(note);

            // Rest Values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }

        // PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
