import { useState } from "react";
import FindBook from "./FindBook";
import TestComponent from "./TestComponent";

function BookPanel() {
  const [isShown, setIsShown] = useState(false);

  const handleClick = (event) => {
    setIsShown((current) => !current);
  };

  return (
    <div>
      <div>
        <button onClick={handleClick}>Find a book</button>
        {isShown && <FindBook />}
      </div>
      <div>
        <button>Add a new book</button>
      </div>
      <div>
        <button>Delete a book</button>
      </div>
    </div>
  );
}

export default BookPanel;
