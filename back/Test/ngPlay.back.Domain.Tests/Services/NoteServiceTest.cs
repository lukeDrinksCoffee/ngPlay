using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.Domain.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace ngPlay.back.Domain.Tests.Services
{
    ///////////////////////////////////////////////////////
    // Test naming convention
    //
    //    UnitOfWork_StateUnderTest_ExpectedOutcome
    //

    [TestFixture]
    public class NoteServiceTest
    {
        [Test]
        public void DeleteNote_NoNoteToDelete_NotFoundReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            // ACT
            var result = noteService.DeleteNote(1, 1);

            // ASSERT
            Assert.AreEqual(ServiceResponse.NotFound, result);
        }

        [Test]
        public void DeleteNote_NoteDoesntBelongToUser_NotAuthorisedReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            noteRepositoryMock.Stub(x => x.Get(1)).Return(new Note { Id = 1, UserId = 2 } );

            // ACT
            var result = noteService.DeleteNote(1, 1);

            // ASSERT
            Assert.AreEqual(ServiceResponse.NotAuthorised, result);
        }

        [Test]
        public void DeleteNote_AllowedToDelete_NoteDeleted()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            noteRepositoryMock.Stub(x => x.Get(1)).Return(new Note { Id = 1, UserId = 1 });

            // ACT
            var result = noteService.DeleteNote(1, 1);

            // ASSERT
            Assert.AreEqual(ServiceResponse.Ok, result);
            noteRepositoryMock.AssertWasCalled(x => x.Delete(1));
        }


        // CreateNote
        [Test]
        public void CreateNote_NotePassedToRepositoryForCreation_Succeeds()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            var userId = 1;
            var title = "title";
            var content = "content";
            Note note = null;

            // ACT
            var result = noteService.CreateNote(userId, title, content, out note);

            // ASSERT
            Assert.AreEqual(ServiceResponse.Ok, result);
            Assert.IsNotNull(note);
        }

        [Test]
        public void UpdateNote_NullNoteProvided_ErrorResponseReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            var userId = 1;
            Note note = null;

            // ACT
            var result = noteService.UpdateNote(userId, note);

            // ASSERT
            Assert.AreEqual(ServiceResponse.Error, result);
        }

        [Test]
        public void UpdateNote_NoteDoesntExist_NotFoundResponseReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            var userId = 1;
            var note = new Note { Id = 1 };

            // ACT
            var result = noteService.UpdateNote(userId, note);

            // ASSERT
            Assert.AreEqual(ServiceResponse.NotFound, result);
        }

        [Test]
        public void UpdateNote_UserDoesntOwnNote_NotAuthorisedResponseReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            var userId = 1;
            var note = new Note { Id = 1 };

            noteRepositoryMock.Stub(x => x.Get(1)).Return(new Note { Id = 1, UserId = 2 });

            // ACT
            var result = noteService.UpdateNote(userId, note);

            // ASSERT
            Assert.AreEqual(ServiceResponse.NotAuthorised, result);
        }

        [Test]
        public void UpdateNote_NoteOkToUpdate_NotePassedToRepositoryForUpdateAndOkReturned()
        {
            // ARRANGE
            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            var noteService = new NoteService(noteRepositoryMock);

            var userId = 1;
            var note = new Note { Id = 1 };

            noteRepositoryMock.Stub(x => x.Get(1)).Return(new Note { Id = 1, UserId = 1 });

            // ACT
            var result = noteService.UpdateNote(userId, note);

            // ASSERT
            Assert.AreEqual(ServiceResponse.Ok, result);
            noteRepositoryMock.AssertWasCalled(x => x.Update(note));
        }
    }
}
