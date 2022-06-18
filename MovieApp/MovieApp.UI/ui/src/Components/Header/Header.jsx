import React from 'react'
import "./Header.css"
import {Link} from "react-router-dom"

const Header = () => {
  return (
    <Link to="">
      <span onClick={() => window.scroll(0, 0)} className="header">
        🎬 IMDB Movie Hub 🎥
      </span>
    </Link>
  )
}

export default Header