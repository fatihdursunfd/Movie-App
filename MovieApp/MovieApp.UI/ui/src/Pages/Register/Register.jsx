import React from 'react';
import {Link} from "react-router-dom";
import { useRef, useState, useEffect, useContext } from 'react';
import { Context } from '../../Context/Context';
import "../Login/Login.css"

const Register = () => {

    const userRef = useRef();
    const emailRef = useRef();
    const passwordRef = useRef();
    const errRef = useRef();

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);

    const { dispatch, isFetching } = useContext(Context);

    const handleSubmit = async (e) => { 
        e.preventDefault();
        console.log(userRef.current.value)
        console.log(emailRef.current.value)
        console.log(passwordRef.current.value)
    }

    return (
        <div className='formModal'>
            <section>
                <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>
                <h1>Register</h1>
                <form onSubmit={handleSubmit}>
                    <label htmlFor="username">Email:</label>
                    <input
                        type="text"
                        id="username"
                        ref={userRef}
                        autoComplete="off"
                        onChange={(e) => setUser(e.target.value)}
                        required
                        aria-describedby="uidnote"
                    />
                    <label htmlFor="username">Username:</label>
                    <input
                        type="text"
                        id="username"
                        ref={userRef}
                        autoComplete="off"
                        onChange={(e) => setUser(e.target.value)}
                        required
                        aria-describedby="uidnote"
                    />
                    <label htmlFor="password">Password: </label>
                    <input
                        type="password"
                        id="password"
                        onChange={(e) => setPwd(e.target.value)}
                        ref={passwordRef}
                        required
                        aria-describedby="pwdnote"
                    />

                    <button>Sign Up</button>
                </form>
                <p>
                    Already registered?<br />
                    <span className="line">
                        <Link to="/login"> 
                            Sign In
                        </Link>
                    </span>
                </p>
            </section>
    </div>
  )
}

export default Register
