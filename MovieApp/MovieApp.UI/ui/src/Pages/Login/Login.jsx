import React from 'react';
import {Link} from "react-router-dom";
import { useRef, useState, useEffect, useContext } from 'react';
import { Context } from '../../Context/Context';
import { useNavigate } from 'react-router-dom';
import "./Login.css";

const Login = () => {

    //const { setAuth } = useContext(AuthContext);
    const userRef = useRef();
    const passwordRef = useRef();
    const errRef = useRef();

    const navigate = useNavigate()

    const [user, setUser] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);

    const { dispatch, isFetching } = useContext(Context);
    
    const handleSubmit = async (e) => { 
        e.preventDefault();

        dispatch({ type: "LOGIN_START" });

        if(userRef.current.value === "fatih.dursun.616@gmail.com" && passwordRef.current.value === "fd61"){
            const userId = 61
            dispatch({ type: "LOGIN_SUCCESS", payload: userId });
            navigate("/")
        }
        else{
            dispatch({ type: "LOGIN_FAILURE" });
        }
    }

    return (
        <>
        <span className='pageTitle' > Login </span>
        <div className='formModal'>
        <section>
            <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>
            <h1>Sign In</h1>
            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username:</label>
                <input
                    type="text"
                    id="username"
                    ref={userRef}
                    autoComplete="off"
                    onChange={(e) => setUser(e.target.value)}
                    required
                />

                <label htmlFor="password">Password:</label>
                <input
                    type="password"
                    id="password"
                    ref={passwordRef}
                    onChange={(e) => setPwd(e.target.value)}
                    required
                />
                <button>Sign In</button>
            </form>
            <p>
                Need an Account?<br />
                <span className="line">
                    <Link to="/register" >
                        Sign Up
                    </Link>
                </span>
            </p>
        </section>
    </div>
    </>
  )
}

export default Login
