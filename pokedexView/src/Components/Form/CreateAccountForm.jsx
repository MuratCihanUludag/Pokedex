import React,{useRef} from 'react'
import Eggs from "../../assets/Eggs.png"

function RegistrationForm() {
    const formRef = useRef(null)
    const Submit=()=>{
        var formData = Object.fromEntries(new FormData (formRef.current).entries())
        console.log(formData)
    }
  return (
    <form ref={formRef} className="create-account-form" >
    <div className="card">
      <div className="card-header">
          <img src={Eggs} alt="Egss"  className="eggs-icon"/>
          <h4 className="card-title">Create Account</h4>
      </div>
        <div className="form-group">
          <input name='FirstName' required placeholder="First Name" type="text" />
          <input name='Surname' required placeholder="Surname" type="text" />
        </div>
        <div className="form-group">
          <input name='Email' required placeholder="Email" type="email" />
          <input name='PhoneNumber' required placeholder="PhoneNumber" type="tel"  />
        </div>
        <div className="form-group">
          <input name="Password" required placeholder="Password" type="text" />
          <input name='CurrentPassword' required placeholder="Current Password" type="text" />
        </div>
        <div className="form-bottom ">
          <i/>
          <button onClick={Submit} className="btn float-right" >Create Account</button>
        </div>
    </div>
</form>
  )
}

export default RegistrationForm
