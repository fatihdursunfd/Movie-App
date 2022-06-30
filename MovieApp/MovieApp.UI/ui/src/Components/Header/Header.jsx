import "./Header.css"
import {Link} from "react-router-dom"

const Header = () => {


  return (
    
      <div className='header'>
          <Link to="">
              <span onClick={() => window.scroll(0, 0)} >
                🎬 IMDB Movie Hub 🎥 
              </span>
          </Link>
      </div>
  )
}

export default Header