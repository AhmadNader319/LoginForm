import { useState } from "react";
import "./styles.css";
const entry = {
  id: "",
  Name: "",
  password: ""
};

export default function New (props) {
  const [newEntry, setNewEntry] = useState(entry);

  const addNewUser = () => {
    console.log("The New User Is: ", newEntry);

    fetch("api/User", {
      method: "POST",
      body: JSON.stringify(newEntry),
      headers: {
        "Content-Type": "application/json"
      }
    })
      .then((r) => {
        console.log("Response from Backend for adding new user: ", r);
        if (r.ok) {
          // Redirect or provide some success message
          window.location = "/";
        } else {
          // Handle error response
          console.error("Error adding new user:", r.statusText);
        }
      })
      .catch((e) => console.log("Error adding new user: ", e));
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewEntry((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  return (
    <div>
      <h1>Login</h1>
      <div>
        <label htmlFor="fn">Name</label>
        <input type="text" name="Name" id="Name" onChange={handleInputChange}
        />
      </div>
      <div>
        <label htmlFor="t">Password</label>
        <input
          type="text"
          name="text"
          id="Password"
          onChange={handleInputChange}
        />
      </div>
      <div className="mt-30 row p20 justify-btw">
        <div className="btn cancel" onClick={() => (window.location = "/")}>
          Cancel
        </div>
        <div className="btn add" onClick={addNewUser}>
          Login
        </div>
      </div>
    </div>
  );
}
