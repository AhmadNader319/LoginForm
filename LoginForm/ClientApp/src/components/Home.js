import { useEffect, useState } from "react";
import "./styles.css";
export default function Home ()
{
  

  const [users, setUsers] = useState( [] );
  const [sid, setSid] = useState( "" );

  useEffect( () =>
  {
    fetch( "api/User" ).then( r => r.json() ).then( d =>
    {
      console.log( "The users are: ", d );
      setUsers( d );
    } ).catch( e => console.log( "The error fetching all users: ", e ) );
  }, [] );

  return (
    <main>
      <h1>User</h1>
      <div className="add-btn">
        <a href="/new">+</a>
      </div>

      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {
            users.length === 0 ? <tr className="row waiting"><td className="row">Loading<span className="loading">...</span></td></tr> :
            users.map( User => <tr key={User.ID}>
                <td>{User.Name}</td>
                <td>{User.Password}</td>
              </tr> )
          }
        </tbody>
      </table>


    </main>
  );
}