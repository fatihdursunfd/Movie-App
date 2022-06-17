import React, { useState } from 'react'
import axios from "axios"

const Trending = async () => {
  const [content , setContent] = useState([])
  const {data} = await axios.get(`https://api.themoviedb.org/3/trending/movie/week?api_key=44f4b50a7a7b8ece939348ff65ba06f3`)

  console.log(data);
  setContent(data.results)

  return (
    <div>Trending</div>
  )   
}

export default Trending