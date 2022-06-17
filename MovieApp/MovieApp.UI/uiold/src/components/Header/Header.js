import "./header.css"

const Header = () => {
  return (
    <span onClick={() => window.scroll(0, 0)} className="header">
      🎬 IMDB Movie Hub 🎥
    </span>
  )
}

export default Header