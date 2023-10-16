import { useState } from "react";

function BookForm() {
  const [bookTitle, setBookTitle] = useState("");
  const handleSubmit = (event) => {
    event.preventDefault();
  };
  return (
    <form onSubmit={handleSubmit}>
      <label>Book Title</label>
      <input
        type="text"
        value={bookTitle}
        onChange={(e) => setBookTitle(e.target.value)}
      ></input>

      <button onClick={setBookTitle}>Submit</button>
    </form>
  );
}

export default BookForm;
