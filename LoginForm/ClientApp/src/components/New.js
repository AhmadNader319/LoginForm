import "./styles.css";

const entry = {
  Name: "",
  Password: ""
};

export default function New(props) {

    const addNewUser = () => {

        console.log(entry);
     fetch("api/User", {
      method: "POST",
      body: JSON.stringify(entry),
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

    const newData = (e) => {
        const name = e.target.name;
        let value = e.target.value;
        console.log(name + " " + value);
        entry[name] = value;
    };

    return (


        <div>
             <h1>Login</h1>

            <div className="mt-10">
                <label htmlFor="fn">First Name</label>
                <input type="text" name="Name" id="Name" onChange={newData} />
            </div>

            <div className="mt-10">
                <label htmlFor="ln">Last Name</label>
                <input type="text" name="Password" id="Password" onChange={newData} />
            </div>
            <div className="mt-30 row p20 justify-btw">
                <div className="btn cancel" onClick={() => (window.location = "/")}>Cancel</div>
                <div className="btn add" onClick={addNewUser}>Login</div>
            </div>
        </div>
        
    );
}
