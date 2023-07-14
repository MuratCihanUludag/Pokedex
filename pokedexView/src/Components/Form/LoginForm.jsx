import React,{ useRef } from 'react'
import Eggs from "../../assets/Eggs.png"
import {Link} from "react-router-dom"

function LoginForm() {
    const formRef = useRef(null)
    const Submit = ()=>  {
        var formData = Object.fromEntries(new FormData (formRef.current).entries())
        console.log(formData)
      }
  return (
    <form ref={formRef} className="login-form">
        <div className="card">
            <div className="card-header">
                <img src={Eggs} alt="Egss"  className="eggs-icon"/>
                <h4 className="card-title">Login</h4>
            </div>
            <div className="form-group username">
                <input name="username" type="text" placeholder="UserName" />
            </div>
            <div className="form-group password">
                <input name="password" type="text" placeholder="Password" />
            </div>
            <div className='form-bottom' >
                <p>Do Not Have An Account?<Link className='link' to="/registration"><span> Create new Account</span></Link> </p>
                <button onClick={Submit} type="button" className="btn  float-right">GOTCHA</button>
            </div>
        </div>
  </form>
  )
}

export default LoginForm
