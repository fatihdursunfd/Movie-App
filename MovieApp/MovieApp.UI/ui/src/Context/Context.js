import { createContext, useEffect, useReducer } from "react";
import Reducer from "./Reducer";

const INITIAL_STATE = {
    user : localStorage.getItem("user"),
    isFecthing : false,
    error : false
}
export const Context = createContext(INITIAL_STATE);

export const ContextProvider = ({ children }) => {

    const [state, dispatch] = useReducer(Reducer, INITIAL_STATE);
  
    useEffect(() => {
        localStorage.setItem("user" , (state.user));
    }, [state.user]);

    return (
        <Context.Provider
          value={{
            user: state.user,
            isFetching: state.isFetching,
            error: state.error,
            dispatch,
          }}
        >
          {children}
        </Context.Provider>
      );
}