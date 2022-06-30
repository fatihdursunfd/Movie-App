import { useEffect, useContext } from 'react'
import { useNavigate } from 'react-router-dom'
import { Context } from '../../Context/Context'

const Logout = () => {
    const navigate = useNavigate()
    const { dispatch, isFetching } = useContext(Context);

    useEffect(() => {
        localStorage.removeItem("user")
        dispatch({ type: "LOGOUT", payload: null });
        navigate("/login")
    })
}

export default Logout