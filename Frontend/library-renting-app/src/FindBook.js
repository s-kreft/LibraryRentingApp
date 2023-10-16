import { useState } from "react";

function FindBook() {
  const [bookTitle, setBookTitle] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Find a book</label>
      <input
        type="text"
        name="bookTitle"
        value={bookTitle}
        onChange={(e) => setBookTitle(e.target.value)}
      />
      <button>Submit</button>
    </form>
  );
}
export default FindBook;
