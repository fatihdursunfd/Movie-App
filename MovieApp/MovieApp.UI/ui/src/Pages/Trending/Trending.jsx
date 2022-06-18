import React , { useEffect, useState } from 'react'
import axios from "axios"
import Single from "../../Components/Single/Single"
import "./Trending.css"
import CustomPagination from "../../Components/Pagination/CustomPagination" 

const Trending = () => {

  const [page, setPage] = useState(1);
  const [content , setContent] = useState([])

  const fetchTrending = async () => {
    const {data} = await axios.get(`https://api.themoviedb.org/3/trending/movie/week?api_key=44f4b50a7a7b8ece939348ff65ba06f3&page=${page}`)
    setContent(data.results)
  }

  useEffect( () => {
    fetchTrending();  
  } , [page])

  return (
    <div>
        <span className='pageTitle' > Trending </span>
        <div className='trending'>
            {content.map( (c) => 
                < Single 
                  key={c.id}
                  id={c.id}
                  poster={c.poster_path}
                  title={c.title || c.name}
                  date={c.first_air_date || c.release_date}
                  media_type={c.media_type}
                  vote_average={c.vote_average}
                />
            )}
        </div>
        <CustomPagination setPage={setPage} />
    </div>
  )
}

export default Trending